using Newtonsoft.Json;
	
namespace MTSChrzanow.Models
{
	public class Team
	{
		public int Index { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		public int Points
		{
			get => Wins * 3 + DrawsWins * 2 + DrawsLosses * 1;
		}

		public int Games
		{
			get => Wins + DrawsWins + DrawsLosses;
		}

		[JsonProperty("wins")]
		public int Wins { get; set; }
		[JsonProperty("losses")]
		public int Losses { get; set; }
		[JsonProperty("draws-losses")]
		public int DrawsLosses { get; set; }
		[JsonProperty("draws-wins")]
		public int DrawsWins { get; set; }
		[JsonProperty("logo-url")]
		public string LogoUrl { get; set; }
		[JsonProperty("goals-for")]
		public int GoalsFor { get; set; }
		[JsonProperty("goals-against")]
		public int GoalsAgainst { get; set; }

		public static string MTSChrzanow => "MTS Chrzanów";
		public static string MKSOlimpiaMEDEX => "MKS Olimpia MEDEX Piekary Śląskie";
		public static string SMSZPRPKielce => "SMS ZPRP Kielce";
		public static string ORLENUpstreamCzuwaj => "ORLEN Upstream Czuwaj Przemyśl";
		public static string MUKSZaglebie => "MUKS Zagłębie ZSO 14 Sosnowiec";
		public static string KSSPR => "KSSPR Końskie";
		public static string KSViret => "KS Viret CMC Zawiercie";
		public static string MKSPadwa => "MKS Padwa Zamość";
		public static string SPRWisla => "SPR Wisła Sandomierz";
		public static string KSZOOstrowiec => "KSZO Ostrowiec Świętokrzyski";
		public static string AZSUJK => "AZS UJK Kielce";
	}
}
