﻿namespace MTSChrzanow.Models
{
	public class MainMenuItem
	{
		public enum MenuItemType
		{
			Posts,
			Table,
			Players,
			Sponsors,
			RealtimeGame,
			About
		}

		public MenuItemType Type { get; set; }
		public string Title { get; set; }

		public override string ToString() => Title;
	}
}
