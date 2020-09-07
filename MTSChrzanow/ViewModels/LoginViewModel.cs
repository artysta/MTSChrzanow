using MTSChrzanow.Models;
using MTSChrzanow.Views	;
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
			await _navigation.PushAsync(new MainPage());
		}
	}
}
