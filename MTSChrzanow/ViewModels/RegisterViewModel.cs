using MTSChrzanow.Models;
using MTSChrzanow.Views	;
using System.Windows.Input;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	public class RegisterViewModel : BaseViewModel
	{
		private INavigation _navigation;
		private ICommand _registerCommand;

		public ICommand LoginCommand => _registerCommand ?? (_registerCommand = new Command(OnRegister));
		
		public RegisterViewModel(INavigation navigation)
		{
			_navigation = navigation;
		}

		private async void OnRegister()
		{
			await _navigation.PushAsync(new LoginPage());
		}
	}
}
