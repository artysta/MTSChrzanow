using MTSChrzanow.Models;

namespace MTSChrzanow.ViewModels
{
	public class PlayerDetailsViewModel : BaseViewModel
	{
		private MTSPlayer _mtsPlayer;
		public MTSPlayer MTSPlayer
		{
			get => _mtsPlayer;
			set
			{
				SetProperty(ref _mtsPlayer, value);
			}
		}

		public PlayerDetailsViewModel() { }

		public PlayerDetailsViewModel(MTSPlayer player)
		{
			MTSPlayer = player;
		}
	}
}
