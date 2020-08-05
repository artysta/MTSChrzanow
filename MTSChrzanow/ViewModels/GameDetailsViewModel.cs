using MTSChrzanow.Models;

namespace MTSChrzanow.ViewModels
{
	public class GameDetailsViewModel : BaseViewModel
	{
		private Game _game;
		public Game Game
		{
			get => _game;
			set
			{
				SetProperty(ref _game, value);
			}
		}

		public GameDetailsViewModel() { }

		public GameDetailsViewModel(Game game)
		{
			Game = game;
		}
	}
}
