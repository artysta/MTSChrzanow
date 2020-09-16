using MTSChrzanow.Helpers;
using MTSChrzanow.Models;
using MTSChrzanow.Views;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	class GamesViewModel : BaseViewModel
	{
		private bool _isBusy;
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

		public bool IsBusy
		{
			get { return _isBusy; }
			set
			{
				SetProperty(ref _isBusy, value);
			}
		}

		public GamesViewModel() : this(null) { }

		public GamesViewModel(INavigation navigation)
		{
			_navigation = navigation;
			InitializeGamesList();
		}
		public async void InitializeGamesList()
		{
			IsBusy = true;
			App.ViewModel.LoggedUser.Token = await UserHelper.GetAccessTokenAsync();
			await SetAllGames();
			IsBusy = false;
		}

		private async Task SetAllGames()
		{
			string query = QueryBuilder.CreateQuery(App.MTSChrzanowFirebaseUrl,
													App.MTSChrzanowFirebaseGamesUrl,
													App.MTSChrzanowFirebaseAuth,
													App.ViewModel.LoggedUser.Token);

			string json = await new WebClient().DownloadStringTaskAsync(query);
			var games = JsonConvert.DeserializeObject<List<Game>>(json);

			Games = new ObservableCollection<Game>(games);
		}
		private async void OnGameItemClicked(Game game)
		{
			await _navigation.PushAsync(new GameDetailsPage(game));
		}
	}
}
