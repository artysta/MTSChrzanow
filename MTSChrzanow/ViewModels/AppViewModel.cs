using MTSChrzanow.Models;
using Xamarin.Essentials;

namespace MTSChrzanow.ViewModels
{
	public class AppViewModel : BaseViewModel
	{
		public User LoggedUser { get; set; }

		public AppViewModel()
		{
			LoggedUser = new User()
			{
				Email = Preferences.Get("REMEMBERED_USER", "N/A")
			};
		}
	}
}
