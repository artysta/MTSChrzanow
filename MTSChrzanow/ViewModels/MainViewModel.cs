using Android.Content.Res;
using MTSChrzanow.Models;
using MTSChrzanow.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private INavigation _navigation;
		private ICommand _goToPostsCommand;

		public ICommand GoToPostsCommand => _goToPostsCommand ?? (_goToPostsCommand = new Command(OnGoToPosts));

		private async void OnGoToPosts()
		{
			await _navigation.PushAsync(new PostsPage());
		}

		public MainViewModel() { }

		public MainViewModel(INavigation navigation)
		{
			_navigation = navigation;
		}
	}
}
