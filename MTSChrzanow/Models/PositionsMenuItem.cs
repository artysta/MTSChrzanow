namespace MTSChrzanow.Models
{
	public class PositionsMenuItem
	{
		public enum MenuItemType
		{
			Goalkeepers,
			Fullbacks,
			CircleRunners,
			Wingers
		}

		public MenuItemType Type { get; set; }
		public string Title { get; set; }

		public override string ToString() => Title;
	}
}
