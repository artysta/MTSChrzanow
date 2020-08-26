using MTSChrzanow.Models;

namespace MTSChrzanow.ViewModels
{
	public class GameDetailsViewModel : BaseViewModel
	{
		private Game _game;
		private string _message;

		public Game Game
		{
			get => _game;
			set
			{
				SetProperty(ref _game, value);
			}
		}

		public string Message
		{
			get => _message;
			set
			{
				SetProperty(ref _message, value);
			}
		}

		public GameDetailsViewModel() { }

		public GameDetailsViewModel(Game game)
		{
			Game = game;
			string date = $"{ game.DateOfGame.Day }/{ game.DateOfGame.Month }/{ game.DateOfGame.Year }";
			string time = $"{ game.DateOfGame.Hour }:{ game.DateOfGame.Minute }";
			Message = game.IsFinished ? $"Mecz odbył się { date } o godzinie { time }."
									  : $"Mecz się jeszcze nie odbył. Spotkanie będzie miało miejsce { date } o godzinie  { time }.";
		}
	}
}
