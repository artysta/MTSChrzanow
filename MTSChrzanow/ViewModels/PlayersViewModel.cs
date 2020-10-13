using MTSChrzanow.Models;
using MTSChrzanow.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	public class PlayersViewModel : BaseViewModel
	{
		private INavigation _navigation;

		private ICommand _goToPlayerDetailsCommand;
		public ICommand GoToPlayerDetailsCommand =>
			_goToPlayerDetailsCommand ?? (_goToPlayerDetailsCommand = new Command<Player>(OnGoToPlayerDetails));

		private ObservableCollection<Player> _players;
		public ObservableCollection<Player> MTSPlayers
		{
			get => _players;
			set => SetProperty(ref _players, value);
		}
		
		public string PositionName { get; set; }

		public PlayersViewModel(INavigation navigation, PositionsMenuItem position)
		{
			if (position != null)
			{
				PositionName = position.Title;
				_navigation = navigation;
				InitializePlayersList(position.Type);
			}
		}

		public void InitializePlayersList(PositionsMenuItem.MenuItemType type)
		{
			List<Player> items = PlayersData.GetPlayers(type);
			MTSPlayers = new ObservableCollection<Player>(items);
		}

		private async void OnGoToPlayerDetails(Player player)
		{
			if (player != null)
			{
				await _navigation.PushAsync(new PlayerDetailsPage(player));
			}
		}
	}
}
