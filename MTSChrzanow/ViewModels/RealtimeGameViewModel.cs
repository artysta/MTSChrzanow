using Firebase.Database;
using MTSChrzanow.Helpers;
using MTSChrzanow.Models;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace MTSChrzanow.ViewModels
{
	public class RealtimeGameViewModel : BaseViewModel
	{
		private RealtimeGame _realtimeGame;
		private bool _isBusy;
		private bool _isGameGoing;

		public RealtimeGame RealtimeGame
		{
			get => _realtimeGame;
			set
			{
				SetProperty(ref _realtimeGame, value);
			}
		}

		public bool IsBusy
		{
			get => _isBusy;
			set
			{
				SetProperty(ref _isBusy, value);
			}
		}

		public bool IsGameGoing
		{
			get => _isGameGoing;
			set
			{
				SetProperty(ref _isGameGoing, value);
			}
		}

		public FirebaseClient Firebase { get; set; }

		public RealtimeGameViewModel()
		{
			Initialize();
		}

		public async void Initialize()
		{
			IsBusy = true;
			App.ViewModel.LoggedUser.Token = await UserHelper.GetAccessTokenAsync();

			FirebaseOptions auth = new FirebaseOptions()
			{
				AuthTokenAsyncFactory = () => Task.FromResult(App.ViewModel.LoggedUser.Token)
			};

			Firebase = new FirebaseClient(App.MTSChrzanowFirebaseUrl, auth);
			StartListening();
		}

		public void StartListening()
		{
			var observable = Firebase
			  .Child(App.MTSChrzanowRealTimeGameChild)
			  .AsObservable<RealtimeGame>()
			  .Subscribe(game =>
			  {
				  if (game.Key.Equals(""))
				  {
					  IsGameGoing = false;
				  }
				  else
				  {
					  IsGameGoing = true;
					  RealtimeGame = game.Object;
				  }
				  if (IsBusy) IsBusy = false;
			  });
		}

	}
}
