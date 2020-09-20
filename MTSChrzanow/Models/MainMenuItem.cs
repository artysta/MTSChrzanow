namespace MTSChrzanow.Models
{
	public class MainMenuItem
	{
		public enum MenuItemType
		{
			Posts,
			Schedule,
			Players,
			Sponsors,
			RealtimeGame,
			UserProfile,
			About
		}

		public MenuItemType Type { get; set; }
		public string Title { get; set; }

		public override string ToString() => Title;
	}
}
