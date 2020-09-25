using MTSChrzanow.Models;
using MTSChrzanow.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	public class PositionsViewModel : BaseViewModel
	{
		private INavigation _navigation;

		private ICommand _goToPositionCommand;
		public ICommand GoToSelectedPage => _goToPositionCommand ?? (_goToPositionCommand = new Command<PositionsMenuItem>(OnPositionItemClicked));

		private ObservableCollection<PositionsMenuItem> _menuItems;
		public ObservableCollection<PositionsMenuItem> MenuItems
		{
			get => _menuItems;
			set => SetProperty(ref _menuItems, value);
		}

		public PositionsViewModel(INavigation navigation)
		{
			_navigation = navigation;
			InitializeMenu();
		}

		public void InitializeMenu()
		{
			List<PositionsMenuItem> items = new List<PositionsMenuItem>
			{
				new PositionsMenuItem { Type = PositionsMenuItem.MenuItemType.Goalkeepers, Title = "Bramkarze" },
				new PositionsMenuItem { Type = PositionsMenuItem.MenuItemType.Fullbacks, Title = "Rozgrywający" },
				new PositionsMenuItem { Type = PositionsMenuItem.MenuItemType.CircleRunners, Title = "Obrotowi" },
				new PositionsMenuItem { Type = PositionsMenuItem.MenuItemType.Wingers, Title = "Skrzydłowi" },
			};

			MenuItems = new ObservableCollection<PositionsMenuItem>(items);
		}
				
		private async void OnPositionItemClicked(PositionsMenuItem item)
		{
			if (item != null)
			{
				await _navigation.PushAsync(new PlayersPage(item));
			}
		}
	}
}
