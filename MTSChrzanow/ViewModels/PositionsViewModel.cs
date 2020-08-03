using Android.Content.Res;
using MTSChrzanow.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using MTSChrzanow.Models;

namespace MTSChrzanow.ViewModels
{
	public class PositionsViewModel : BaseViewModel
	{
		private ObservableCollection<PositionsMenuItem> _menuItems;
		private INavigation _navigation;
		private ICommand _goToPositionCommand;
		
		public ICommand GoToSelectedPage => _goToPositionCommand ?? (_goToPositionCommand = new Command<PositionsMenuItem>(OnPositionItemClicked));

		public PositionsViewModel() : this(null)	{ }

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

		public ObservableCollection<PositionsMenuItem> MenuItems
		{
			get { return _menuItems; }
			set
			{
				SetProperty(ref _menuItems, value);
			}
		}
		
		private async void OnPositionItemClicked(PositionsMenuItem item)
		{
			if (item == null)
				return;

			await _navigation.PushAsync(new PlayersPage(item.Type));
		}
	}
}
