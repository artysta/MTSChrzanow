using Firebase.Database;
using MTSChrzanow.Helpers;
using MTSChrzanow.Models;
using MTSChrzanow.Views;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	public class RealtimeGameViewModel : BaseViewModel
	{
		private RealtimeGame _realtimeGame;
		public RealtimeGame RealtimeGame
		{
			get => _realtimeGame;
			set => SetProperty(ref _realtimeGame, value);
		}

		private bool _isBusy;
		public bool IsBusy
		{
			get => _isBusy;
			set => SetProperty(ref _isBusy, value);
		}

		private bool _isGameGoing;
		public bool IsGameGoing
		{
			get => _isGameGoing;
			set => SetProperty(ref _isGameGoing, value);
		}

		public FirebaseClient Firebase { get; set; }

		public RealtimeGameViewModel() => Initialize();

		public async void Initialize()
		{
			IsBusy = true;

			try
			{
				//FirebaseNetworkException
				App.ViewModel.LoggedUser.Token = await UserHelper.GetAccessTokenAsync();
			}
			catch (Exception)
			{
				await Application.Current.MainPage.DisplayAlert("Uwaga!", "Coś poszło nie tak! Sprawdź połączenie internetowe! :(", "Ok");
				(Application.Current).MainPage = new NavigationPage(new MainPage());
				return;
			}

			FirebaseOptions auth = new FirebaseOptions()
			{
				AuthTokenAsyncFactory = () => Task.FromResult(App.ViewModel.LoggedUser.Token)
			};

			Firebase = new FirebaseClient(App.ApiFirebaseUrl, auth);
			StartListening();
		}

		public void StartListening()
		{
			var observable = Firebase
			  .Child(App.ApiRealTimeGameChild)
			  .AsObservable<RealtimeGame>()
			  .Subscribe(game =>
			  {
				  if (game.Key.Equals("") || !game.Object.IsGoing)
				  {
					  IsGameGoing = false;
				  }
				  else
				  {
					  IsGameGoing = true;
					  RealtimeGame = game.Object;
				  }

				  if (IsBusy)
				  {
					  IsBusy = false;
				  }
			  });
		}

	}
}
