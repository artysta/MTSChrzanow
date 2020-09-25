using MTSChrzanow.Helpers;
using MTSChrzanow.Models;
using MTSChrzanow.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	public class LoginViewModel : BaseViewModel
	{
		private INavigation _navigation;

		private ICommand _goToRegisterPageCommand;
		public ICommand GoToRegisterCommand => _goToRegisterPageCommand ?? (_goToRegisterPageCommand = new Command(OnGoToRegisterPage));

		private ICommand _loginCommand;
		public ICommand LoginCommand => _loginCommand ?? (_loginCommand = new Command(OnLogin));

		private string _email = "";
		public string Email
		{
			get => _email;
			set => SetProperty(ref _email, value);
		}

		private string _password = "";
		public string Password
		{
			get => _password;
			set => SetProperty(ref _password, value);
		}

		private string _token = "";
		public string Token
		{
			get => _token;
			set => SetProperty(ref _token, value);
		}

		private bool _isBusy;
		public bool IsBusy
		{
			get => _isBusy;
			set => SetProperty(ref _isBusy, value);
		}

		private bool _isRememberMeChecked;
		public bool IsRememberMeChecked
		{
			get => _isRememberMeChecked;
			set => SetProperty(ref _isRememberMeChecked, value);
		}

		public LoginViewModel(INavigation navigation) => _navigation = navigation;

		private async void OnGoToRegisterPage() => await _navigation.PushAsync(new RegisterPage());

		private async void OnLogin()
		{
			if (Email.Trim().Equals(""))
			{
				await Application.Current.MainPage.DisplayAlert("Uwaga!", "Pole e-mail nie może być puste!", "Ok");
				return;
			}

			if (Password.Trim().Equals(""))
			{
				await Application.Current.MainPage.DisplayAlert("Uwaga!", "Pole hasło nie może być puste!", "Ok");
				return;
			}

			try
			{
				IsBusy = true;
				Token = await UserHelper.LoginUser(Email, Password);
				IsBusy = false;
			}
			catch (Exception e)
			{
				IsBusy = false;

				// I know that it is not proper way to catch exceptions.
				// I might be wrong, but I think that there is no cross-platform (Xamarin.Forms) Firebase Auth library. That is why I am catching eceptions like this.
				// In this case I should catch exceptions for Android & iOS separately, but I think, that this method is enough good at this moment.
				switch (e.GetType().ToString())
				{
					case "Firebase.Auth.FirebaseAuthInvalidCredentialsException":
						await Application.Current.MainPage.DisplayAlert("Uwaga!", "Email i hasło nie zgadzają się!", "Ok");
						break;
					case "Firebase.Auth.FirebaseAuthWeakPasswordException":
						await Application.Current.MainPage.DisplayAlert("Uwaga!", "Hasło jest zbyt słabe!", "Ok");
						break;
					case "Firebase.FirebaseNetworkException":
						await Application.Current.MainPage.DisplayAlert("Uwaga!", "Wykryto problem z połączeniem internetowym!", "Ok");
						break;
					default:
						await Application.Current.MainPage.DisplayAlert("Uwaga!", "Coś poszło nie tak! :(", "Ok");
						break;
				}

				return;
			}

			App.ViewModel.LoggedUser = new User(Email, Password);

			if (IsRememberMeChecked)
			{
				UserHelper.SaveUserAsync(App.ViewModel.LoggedUser);
			}
			
			(Application.Current).MainPage = new NavigationPage(new MainPage());
			await Application.Current.MainPage.DisplayAlert("Logowanie.", "Pomyślnie zalogowano do konta!", "Ok");
		}
	}
}
