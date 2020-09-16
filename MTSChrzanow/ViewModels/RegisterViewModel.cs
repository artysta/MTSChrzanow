using MTSChrzanow.Helpers;
using MTSChrzanow.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	public class RegisterViewModel : BaseViewModel
	{
		private INavigation _navigation;
		private ICommand _registerCommand;
		public ICommand LoginCommand => _registerCommand ?? (_registerCommand = new Command(OnRegister));

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

		private string _passwordRepeat = "";
		public string PasswordRepeat
		{
			set
			{
				SetProperty(ref _passwordRepeat, value);
			}
			get
			{
				return _passwordRepeat;
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

		public RegisterViewModel(INavigation navigation)
		{
			_navigation = navigation;
		}

		private async void OnRegister()
		{
			if (Email.Trim().Equals(""))
			{
				await Application.Current.MainPage.DisplayAlert("Uwaga!", "Pole e-mail nie może być puste!", "Ok");
				return;
			}

			if (Password.Trim().Equals("") && PasswordRepeat.Trim().Equals(""))
			{
				await Application.Current.MainPage.DisplayAlert("Uwaga!", "Pola dotyczące hasła nie mogą być puste!", "Ok");
				return;
			}

			if (!Password.Trim().Equals(PasswordRepeat.Trim()))
			{
				await Application.Current.MainPage.DisplayAlert("Uwaga!", "Hasła muszą być identyczne!", "Ok");
				return;
			}

			try
			{
				IsBusy = true;
				await UserHelper.RegisterUser(Email, Password);
				IsBusy = false;
				await Application.Current.MainPage.DisplayAlert("Rejestracja.", "Pomyślnie zarejestrowano konto!", "Ok");
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
						await Application.Current.MainPage.DisplayAlert("Uwaga!", "Podaj poprawny adres email!", "Ok");
						break;
					case "Firebase.Auth.FirebaseAuthUserCollisionException":
						await Application.Current.MainPage.DisplayAlert("Uwaga!", "Już istnieje konto o takim emailu!", "Ok");
						break;
					case "Firebase.Auth.FirebaseAuthWeakPasswordException":
						await Application.Current.MainPage.DisplayAlert("Uwaga!", "Hasło jest zbyt słabe!", "Ok");
						break;
					case "Firebase.FirebaseNetworkException":
						await Application.Current.MainPage.DisplayAlert("Uwaga!", "Wykryto problem z połączeniem internetowym!", "Ok");
						break;
					default:
						await Application.Current.MainPage.DisplayAlert("Uwaga!", "Nie udao się utworzyć konta! :(", "Ok");
						break;
				}
				
				return;
			}

			await _navigation.PushAsync(new LoginPage());
		}
	}
}
