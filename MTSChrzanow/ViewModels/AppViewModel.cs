using MTSChrzanow.Helpers;
using MTSChrzanow.Models;

namespace MTSChrzanow.ViewModels
{
	public class AppViewModel : BaseViewModel
	{
		public User LoggedUser { get; set; }

		public AppViewModel() => GetUserData();
		
		public async void GetUserData() => LoggedUser = await UserHelper.GetUserAsync();
	}
}
