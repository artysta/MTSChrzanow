using Android.Content.Res;
using MTSChrzanow.Models;
using MTSChrzanow.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Java.IO;

namespace MTSChrzanow.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private ObservableCollection<MainMenuItem> _menuItems;
		private INavigation _navigation;
		private ICommand _goToPostsCommand;

		public ICommand GoToSelectedPage => _goToPostsCommand ?? (_goToPostsCommand = new Command<MainMenuItem>(OnMenuItemClicked));

		public MainViewModel() : this(null)	{ }

		public MainViewModel(INavigation navigation)
		{
			_navigation = navigation;
			InitializeMenu();
		}

		public void InitializeMenu()
		{
			List<MainMenuItem> items = new List<MainMenuItem>
			{
				new MainMenuItem { Type = MainMenuItem.MenuItemType.Posts, Title = "Aktualności" },
				new MainMenuItem { Type = MainMenuItem.MenuItemType.Table, Title = "Terminarz" },
				new MainMenuItem { Type = MainMenuItem.MenuItemType.Players, Title = "Zawodnicy" },
				new MainMenuItem { Type = MainMenuItem.MenuItemType.Sponsors, Title = "Sponsorzy" },
				new MainMenuItem { Type = MainMenuItem.MenuItemType.RealtimeGame, Title = "Wynik na żywo" },
				new MainMenuItem { Type = MainMenuItem.MenuItemType.UserProfile, Title = "Twój profil" },
				new MainMenuItem { Type = MainMenuItem.MenuItemType.About, Title = "O aplikacji" }
			};

			MenuItems = new ObservableCollection<MainMenuItem>(items);
		}

		public ObservableCollection<MainMenuItem> MenuItems
		{
			get { return _menuItems; }
			set
			{
				SetProperty(ref _menuItems, value);
			}
		}
		
		private async void OnMenuItemClicked(MainMenuItem item)
		{
			if (item == null)
				return;

			switch (item.Type)
			{
				case MainMenuItem.MenuItemType.Posts:
					await _navigation.PushAsync(new PostsPage());
					break;
				case MainMenuItem.MenuItemType.Table:
					await _navigation.PushAsync(new GamesPage());
					break;
				case MainMenuItem.MenuItemType.Players:
					await _navigation.PushAsync(new PositionsPage());
					break;
				case MainMenuItem.MenuItemType.Sponsors:
					await _navigation.PushAsync(new SponsorsPage());
					break;
				case MainMenuItem.MenuItemType.RealtimeGame:
					await _navigation.PushAsync(new RealtimeGamePage());
					break;
				case MainMenuItem.MenuItemType.UserProfile:
					await _navigation.PushAsync(new UserProfilePage());
					break;
				case MainMenuItem.MenuItemType.About:
					await _navigation.PushAsync(new AboutPage());
					break;
				default:
					return;
			}
		}
	}
}
