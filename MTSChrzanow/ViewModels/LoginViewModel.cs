using MTSChrzanow.Views;
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

			await Application.Current.MainPage.DisplayAlert("Logowanie.", "Pomyślnie zalogowano do konta!", "Ok");
			await _navigation.PushAsync(new MainPage());
		}
	}
}
