using MTSChrzanow.Helpers;
using MTSChrzanow.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	public class UserProfileViewModel : BaseViewModel
	{
		private ICommand _logoutCommand;
		public ICommand LogoutCommand => _logoutCommand ?? (_logoutCommand = new Command(OnLogoutButtonClicked));

		private string _loggedUserEmail;
		public string LoggedUserEmail
		{
			get => _loggedUserEmail;
			set => SetProperty(ref _loggedUserEmail, value);
		}

		public UserProfileViewModel() => LoggedUserEmail = App.ViewModel.LoggedUser.Email;

		private async void OnLogoutButtonClicked()
		{
			UserHelper.RemoveUser();
			(Application.Current).MainPage = new NavigationPage(new LoginPage());
			await Application.Current.MainPage.DisplayAlert("Informacja.", "Zostałeś pomyślnie wylogowany!", "Ok");
		}
	}
}
