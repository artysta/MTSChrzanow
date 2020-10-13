using MTSChrzanow.Models;

namespace MTSChrzanow.ViewModels
{
	public class PlayerDetailsViewModel : BaseViewModel
	{
		private Player _player;
		public Player Player
		{
			get => _player;
			set => SetProperty(ref _player, value);
		}

		public PlayerDetailsViewModel(Player player)
		{
			if (player != null)
			{
				Player = player;
			}
		}
	}
}
