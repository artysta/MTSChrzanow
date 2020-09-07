using MTSChrzanow.Views;
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

			await Application.Current.MainPage.DisplayAlert("Rejestracja.", "Pomyślnie zarejestrowano konto!", "Ok");
			await _navigation.PushAsync(new LoginPage());
		}
	}
}
