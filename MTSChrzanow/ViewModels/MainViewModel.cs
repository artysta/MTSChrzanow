using MTSChrzanow.Models;
using MTSChrzanow.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		/*
		
		--> C O D E    F O R    T H E    L I S T    V I E W    L A Y O U T <--
		 
		public ICommand GoToSelectedPage => _goToPostsCommand ?? (_goToPostsCommand = new Command<MainMenuItem>(OnMenuItemClicked));

		*/

		private INavigation _navigation;
		private ICommand _goToSelectedPage;
		public ICommand GoToSelectedPage => _goToSelectedPage ?? (_goToSelectedPage = new Command<string>(OnMenuItemClicked));

		private ObservableCollection<MainMenuItem> _menuItems;
		public ObservableCollection<MainMenuItem> MenuItems
		{
			get => _menuItems;
			set => SetProperty(ref _menuItems, value);
		}

		/*
			
		--> C O D E    F O R    T H E    L I S T    V I E W    L A Y O U T <--
		
		public MainViewModel(INavigation navigation)
		{
			_navigation = navigation;
			InitializeMenu();
		}
			
		*/

		public MainViewModel(INavigation navigation) => _navigation = navigation;

		private async void OnMenuItemClicked(string item)
		{
			if (item == null)
				return;

			switch (item)
			{
				case "Posts":
					await _navigation.PushAsync(new PostsPage());
					break;
				case "Schedule":
					await _navigation.PushAsync(new GamesPage());
					break;
				case "Table":
					await _navigation.PushAsync(new TablePage());
					break;
				case "Players":
					await _navigation.PushAsync(new PositionsPage());
					break;
				case "Sponsors":
					await _navigation.PushAsync(new SponsorsPage());
					break;
				case "RealtimeGame":
					await _navigation.PushAsync(new RealtimeGamePage());
					break;
				case "UserProfile":
					await _navigation.PushAsync(new UserProfilePage());
					break;
				case "About":
					await _navigation.PushAsync(new AboutPage());
					break;
				default:
					return;
			}
		}

		/*

		--> C O D E    F O R    T H E    L I S T    V I E W    L A Y O U T <--

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

		*/
	}
}
