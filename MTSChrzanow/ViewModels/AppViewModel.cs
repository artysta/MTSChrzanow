using MTSChrzanow.Models;
using Xamarin.Essentials;
using System;
using Xamarin.Forms;
using MTSChrzanow.Helpers;

namespace MTSChrzanow.ViewModels
{
	public class AppViewModel : BaseViewModel
	{
		public User LoggedUser { get; set; }

		public AppViewModel()
		{
			GetUserData();
		}

		public async void GetUserData()
		{
			LoggedUser = await UserHelper.GetUserAsync();
		}
	}
}
