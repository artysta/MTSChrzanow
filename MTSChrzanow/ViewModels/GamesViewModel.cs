using MTSChrzanow.Helpers;
using MTSChrzanow.Models;
using MTSChrzanow.Views;
using Newtonsoft.Json;
using System;
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
		private INavigation _navigation;

		private ICommand _goToGameCommand;
		public ICommand GoToGameDetailsCommand => _goToGameCommand ?? (_goToGameCommand = new Command<Game>(OnGameItemClicked));

		private ObservableCollection<Game> _games;
		public ObservableCollection<Game> Games
		{
			get => _games;
			set => SetProperty(ref _games, value);
		}

		private bool _isBusy;
		public bool IsBusy
		{
			get => _isBusy;
			set => SetProperty(ref _isBusy, value);
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
			try
			{
				//FirebaseNetworkException
				App.ViewModel.LoggedUser.Token = await UserHelper.GetAccessTokenAsync();
			}
			catch (Exception e)
			{
				await Application.Current.MainPage.DisplayAlert("Uwaga!", "Coś poszło nie tak! Sprawdź połączenie internetowe! :(", "Ok");
				(Application.Current).MainPage = new NavigationPage(new MainPage());
				return;
			}

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

		private async void OnGameItemClicked(Game game) => await _navigation.PushAsync(new GameDetailsPage(game));
	}
}
