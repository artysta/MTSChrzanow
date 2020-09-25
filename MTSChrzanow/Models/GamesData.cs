using System;
using System.Collections.Generic;

namespace MTSChrzanow.Models
{
	public class GamesData
	{
		public static List<Game> GetGames()
		{
			List<Game> list = new List<Game>();

			list.Add
			(
				new Game
				{
					Home = Team.MTSChrzanow,
					HomeGoal = "",
					Away = Team.SMSZPRPKielce,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("19.09.2020 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.MKSOlimpiaMEDEX,
					HomeGoal = "",
					Away = Team.MTSChrzanow,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("26.09.2020 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.MTSChrzanow,
					HomeGoal = "",
					Away = Team.ORLENUpstreamCzuwaj,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("03.10.2020 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.MUKSZaglebie,
					HomeGoal = "",
					Away = Team.MTSChrzanow,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("10.10.2020 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.MTSChrzanow,
					HomeGoal = "",
					Away = Team.KSSPR,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("17.10.2020 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.KSViret,
					HomeGoal = "",
					Away = Team.MTSChrzanow,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("24.10.2020 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.MTSChrzanow,
					HomeGoal = "",
					Away = Team.MKSPadwa,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("21.11.2020 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.SPRWisla,
					HomeGoal = "",
					Away = Team.MTSChrzanow,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("28.11.2020 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.MTSChrzanow,
					HomeGoal = "",
					Away = Team.KSZOOstrowiec,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("05.12.2020 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.AZSUJK,
					HomeGoal = "",
					Away = Team.MTSChrzanow,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("12.12.2020 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.SMSZPRPKielce,
					HomeGoal = "",
					Away = Team.MTSChrzanow,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("30.01.2021 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.MTSChrzanow,
					HomeGoal = "",
					Away = Team.MKSOlimpiaMEDEX,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("13.02.2021 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.ORLENUpstreamCzuwaj,
					HomeGoal = "",
					Away = Team.MTSChrzanow,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("27.02.2021 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.MTSChrzanow,
					HomeGoal = "",
					Away = Team.MUKSZaglebie,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("20.03.2021 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.KSSPR,
					HomeGoal = "",
					Away = Team.MTSChrzanow,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("27.03.2021 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.MTSChrzanow,
					HomeGoal = "",
					Away = Team.KSViret,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("10.04.2021 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.MKSPadwa,
					HomeGoal = "",
					Away = Team.MTSChrzanow,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("24.04.2021 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.MTSChrzanow,
					HomeGoal = "",
					Away = Team.SPRWisla,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("08.05.2021 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.KSZOOstrowiec,
					HomeGoal = "",
					Away = Team.MTSChrzanow,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("15.05.2021 00:00:00")
				}
			);

			list.Add(
				new Game
				{
					Home = Team.MTSChrzanow,
					HomeGoal = "",
					Away = Team.AZSUJK,
					AwayGoal = "",
					DateOfGame = DateTime.Parse("22.05.2021 00:00:00")
				}
			);

			return list;
		}
	}
}
