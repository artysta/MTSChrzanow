using Newtonsoft.Json;

namespace MTSChrzanow.Models
{
	public class Team
	{
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("points")]
		public int Points { get; set; }
		[JsonProperty("games")]
		public int Games { get; set; }
		[JsonProperty("wins")]
		public int Wins { get; set; }
		[JsonProperty("losses")]
		public int Losses { get; set; }
		[JsonProperty("draws")]
		public int Draws { get; set; }
		[JsonProperty("logo-url")]
		public string LogoUrl { get; set; }
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
