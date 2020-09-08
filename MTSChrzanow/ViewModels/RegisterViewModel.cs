using MTSChrzanow.Views;
using System.Windows.Input;
using Xamarin.Forms;
using System;

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

			IFirebaseAuthenticator auth = DependencyService.Get<IFirebaseAuthenticator>();

			if (auth == null)
			{
				await Application.Current.MainPage.DisplayAlert("Uwaga!", "Coś poszło nie tak! :(", "Ok");
				return;
			}

			try
			{
				var token = await auth.SignupWithEmailPassword(Email, Password);
				System.Diagnostics.Debug.WriteLine($"TOKEN: { token }");
				await Application.Current.MainPage.DisplayAlert("Rejestracja.", "Pomyślnie zarejestrowano konto!", "Ok");
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine($"Exception message: { e.Message }");
				await Application.Current.MainPage.DisplayAlert("Uwaga!", "Nie udao się utworzyć konta! :(", "Ok");
				return;
			}

			await _navigation.PushAsync(new LoginPage());
		}
	}
}
