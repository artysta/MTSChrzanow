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
			set
			{
				SetProperty(ref _email, value);
			}
			get
			{
				return _email;
			}
		}

		private string _password = "";
		public string Password
		{
			set
			{
				SetProperty(ref _password, value);
			}
			get
			{
				return _password;
			}
		}

		private bool _isBusy;
		public bool IsBusy
		{
			set
			{
				SetProperty(ref _isBusy, value);
			}
			get
			{
				return _isBusy;
			}
		}

		public LoginViewModel(INavigation navigation)
		{
			_navigation = navigation;
		}

		private async void OnGoToRegisterPage()
		{
			await _navigation.PushAsync(new RegisterPage());
		}

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

			IFirebaseAuthenticator auth = DependencyService.Get<IFirebaseAuthenticator>();

			if (auth == null)
			{
				await Application.Current.MainPage.DisplayAlert("Uwaga!", "Coś poszło nie tak! :(", "Ok");
				return;
			}

			try
			{
				IsBusy = true;
				var token = await auth.LoginWithEmailPassword(Email, Password);
				System.Diagnostics.Debug.WriteLine($"TOKEN: { token }");
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
			await Application.Current.MainPage.DisplayAlert("Logowanie.", "Pomyślnie zalogowano do konta!", "Ok");
			await _navigation.PushAsync(new MainPage());
		}
	}
}
