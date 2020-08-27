using Firebase.Database;
using MTSChrzanow.Models;
using System.Threading.Tasks;

namespace MTSChrzanow.ViewModels
{
	public class RealtimeGameViewModel : BaseViewModel
	{
		private RealtimeGame _realtimeGame;
		private bool _isBusy;

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

		public FirebaseClient FirebaseClient { get; set; }

		public RealtimeGameViewModel()
		{
			FirebaseClient = new FirebaseClient(App.MTSChrzanowFirebaseUrl);
			GetRealtimeGameAsync();
		}

		public async void GetRealtimeGameAsync()
		{
			IsBusy = true;
			Task<RealtimeGame> task = GetRealtimeGame();
			RealtimeGame = await task;
			IsBusy = false;
		}

		public async Task<RealtimeGame> GetRealtimeGame()
		{
			return (await FirebaseClient
			  .Child(App.MTSChrzanowRealTimeGameChild)
			  .OnceSingleAsync<RealtimeGame>());
		}
	}
}
