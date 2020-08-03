﻿using Android.Content.Res;
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
	public class PlayersViewModel : BaseViewModel
	{
		private ObservableCollection<MTSPlayer> _players;
		private INavigation _navigation;
		private ICommand _goToPlayerDetailsCommand;

		public ICommand GoToPlayerDetailsCommand => _goToPlayerDetailsCommand ?? (_goToPlayerDetailsCommand = new Command<MTSPlayer>(OnGoToPlayerDetails));

		public PlayersViewModel() : this(null)	{ }

		public PlayersViewModel(INavigation navigation) : this(navigation, PositionsMenuItem.MenuItemType.Goalkeepers) { }

		public PlayersViewModel(INavigation navigation, PositionsMenuItem.MenuItemType type)
		{
			_navigation = navigation;
			InitializePlayersList(type);
		}

		public void InitializePlayersList(PositionsMenuItem.MenuItemType type)
		{
			List<MTSPlayer> items = MTSPlayersData.GetPlayers(type);
			MTSPlayers = new ObservableCollection<MTSPlayer>(items);
		}

		public ObservableCollection<MTSPlayer> MTSPlayers
		{
			get { return _players; }
			set
			{
				SetProperty(ref _players, value);
			}
		}

		private async void OnGoToPlayerDetails(MTSPlayer player)
		{
			if (player == null)
				return;

			await _navigation.PushAsync(new PlayerDetailsPage(player));
		}
	}
}
