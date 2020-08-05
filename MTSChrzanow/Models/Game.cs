using System;

namespace MTSChrzanow.Models
{
	public class Game
	{
		public string Home { get; set; }
		public string HomeGoal { get; set; }
		public string Away { get; set; }
		public string AwayGoal { get; set; }
		public DateTime DateOfGame { get; set; }
		public override string ToString() => $"Home { Home }, Away { Away }, Date of match { DateOfGame }";
	}
}