using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace MTSChrzanow.Models
{
	public class RealtimeGame : INotifyPropertyChanged
	{
		private string _home;
		private string _homeGoal;
		private string _homeLogoUrl;
		private string _away;
		private string _awayGoal;
		private string _awayLogoUrl;
		private bool _isGoing;

		[JsonProperty("home")]
		public string Home
		{
			get => _home;
			set
			{
				_home = value;
				RaisePropertyChanged("Home");
			}
		}

		[JsonProperty("home-goal")]
		public string HomeGoal
		{
			get => _homeGoal;
			set
			{
				_homeGoal = value;
				RaisePropertyChanged("HomeGoal");
			}
		}

		[JsonProperty("home-logo-url")]
		public string HomeLogoUrl
		{
			get => _homeLogoUrl;
			set
			{
				_homeLogoUrl = value;
				RaisePropertyChanged("HomeLogoUrl");
			}
		}

		[JsonProperty("away")]
		public string Away
		{
			get => _away;
			set
			{
				_away = value;
				RaisePropertyChanged("Away");
			}
		}

		[JsonProperty("away-goal")]
		public string AwayGoal
		{
			get => _awayGoal;
			set
			{
				_awayGoal = value;
				RaisePropertyChanged("AwayGoal");
			}
		}

		[JsonProperty("away-logo-url")]
		public string AwayLogoUrl
		{
			get => _awayLogoUrl;
			set
			{
				_awayLogoUrl = value;
				RaisePropertyChanged("AwayLogoUrl");
			}
		}

		[JsonProperty("is-going")]
		public bool IsGoing
		{
			get => _isGoing;
			set
			{
				_isGoing = value;
				RaisePropertyChanged("IsGoing");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(String name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(name));
		}
	}
}