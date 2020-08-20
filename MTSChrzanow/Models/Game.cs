using Newtonsoft.Json;
using System;
using System.Globalization;

namespace MTSChrzanow.Models
{
	public class Game
	{
		private string _homeGoal;
		private string _awayGoal;
		private string _dateOfGameString;
		[JsonProperty("home")]
		public string Home { get; set; }
		[JsonProperty("home-goal")]
		public string HomeGoal
		{
			get => _homeGoal;
			set
			{
				_homeGoal = value.Trim().Equals("") ? "-" : value;
			}
		}
		[JsonProperty("away")]
		public string Away { get; set; }
		[JsonProperty("away-goal")]
		public string AwayGoal
		{
			get => _awayGoal;
			set
			{
				_awayGoal = value.Trim().Equals("") ? "-" : value;
			}
		}
		[JsonProperty("date-of-game")]
		public string DateOfGameString
		{
			get => _dateOfGameString;
			set
			{
				_dateOfGameString = value;
				DateOfGame = DateTime.Parse(value, new CultureInfo("pl-PL"), DateTimeStyles.NoCurrentDateDefault);
			}
		}
		public DateTime DateOfGame { get; set; }

		[JsonProperty("is-finished")]
		public bool IsFinished { get; set; }
		public override string ToString() => $"Home { Home },Away { Away }, Date of match { DateOfGameString }, Is finished { IsFinished }";
	}
}