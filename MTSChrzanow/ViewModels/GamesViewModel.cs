using MTSChrzanow.Models;
using System.Collections.ObjectModel;
using System.Net;
using Android.Util;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using MTSChrzanow.Views;
using Android.Content.Res;
using System;
using System.Threading.Tasks;

namespace MTSChrzanow.ViewModels
{
	class GamesViewModel : BaseViewModel
	{
		private ObservableCollection<Game> _games;
		private INavigation _navigation;
		private ICommand _goToGameCommand;

		public ICommand GoToGameDetailsCommand => _goToGameCommand ?? (_goToGameCommand = new Command<Game>(OnGameItemClicked));

		public ObservableCollection<Game> Games
		{
			get { return _games; }
			set
			{
				SetProperty(ref _games, value);
			}
		}

		public GamesViewModel() : this(null) { }

		public GamesViewModel(INavigation navigation)
		{
			_navigation = navigation;
			InitializeGamesList();
		}
		public void InitializeGamesList()
		{
			List<Game> items = GamesData.GetGames();
			Games = new ObservableCollection<Game>(items);
		}

		private async void OnGameItemClicked(Game game)
		{
			await _navigation.PushAsync(new GameDetailsPage(game));
		}
	}
}
