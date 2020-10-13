using MTSChrzanow.Views;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace MTSChrzanow.Models
{
	public class PlayersData
	{
		public static List<Player> GetPlayers(PositionsMenuItem.MenuItemType position)
		{
			List<Player> players = new List<Player>();
			Assembly assembly = typeof(PlayerDetailsPage).GetTypeInfo().Assembly;

			switch (position)
			{
				case PositionsMenuItem.MenuItemType.Goalkeepers:
					players.Add(
					new Player
					{
						Name = "Marcin Górkowski",
						Number = 32,
						Position = PlayerPosition.Goalkeeper,
						Nationality = "Polska",
						BirthDate = "02.01.1996",
						Height = 178,
						Weight = 102,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.marcin_gorkowski.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.marcin_gorkowski_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Grzegorz Małodobry",
						Number = 98,
						Position = PlayerPosition.Goalkeeper,
						Nationality = "Polska",
						BirthDate = "05.12.1998",
						Height = 182,
						Weight = 105,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.grzegorz_malodobry.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.grzegorz_malodobry_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Patryk Plaszczak",
						Number = 1,
						Position = PlayerPosition.Goalkeeper,
						Nationality = "Polska",
						BirthDate = "18.02.1994",
						Height = 190,
						Weight = 93,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.patryk_plaszczak.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.patryk_plaszczak_face.jpg", assembly)
					});
					break;
				case PositionsMenuItem.MenuItemType.Fullbacks:
					players.Add(
					new Player
					{
						Name = "Patryk Rola",
						Number = 8,
						Position = PlayerPosition.Fullback,
						Nationality = "Polska",
						BirthDate = "07.06.1995",
						Height = 188,
						Weight = 89,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.patryk_rola.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.patryk_rola_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Marcin Skoczylas",
						Number = 27,
						Position = PlayerPosition.Fullback,
						Nationality = "Polska",
						BirthDate = "01.09.1983",
						Height = 189,
						Weight = 95,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.marcin_skoczylas.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.marcin_skoczylas_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Kacper Węgrzyn",
						Number = 4,
						Position = PlayerPosition.Fullback,
						Nationality = "Polska",
						BirthDate = "08.01.1999",
						Height = 179,
						Weight = 74,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.kacper_wegrzyn.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.kacper_wegrzyn_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Jan Orlicki",
						Number = 18,
						Position = PlayerPosition.Fullback,
						Nationality = "Polska",
						BirthDate = "02.06.1996",
						Height = 178,
						Weight = 82,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.jan_orlicki.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.jan_orlicki_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Przemysław Wierzbic",
						Number = 10,
						Position = PlayerPosition.Fullback,
						Nationality = "Polska",
						BirthDate = "18.04.1995",
						Height = 184,
						Weight = 79,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.przemyslaw_wierzbic.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.przemyslaw_wierzbic_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Marcin Hardzina",
						Number = 50,
						Position = PlayerPosition.Fullback,
						Nationality = "Polska",
						BirthDate = "01.04.2003",
						Height = 0,
						Weight = 0,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.marcin_hardzina.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.marcin_hardzina_face.jpg", assembly)
					});
					break;
				case PositionsMenuItem.MenuItemType.CircleRunners:
					players.Add(
					new Player
					{
						Name = "Michał Olszewik",
						Number = 15,
						Position = PlayerPosition.CircleRunner,
						Nationality = "Polska",
						BirthDate = "01.08.1997",
						Height = 180,
						Weight = 80,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.michal_olszewik.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.michal_olszewik_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Paweł Stroński",
						Number = 25,
						Position = PlayerPosition.CircleRunner,
						Nationality = "Polska",
						BirthDate = "04.07.1992",
						Height = 188,
						Weight = 85,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.pawel_stronski.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.pawel_stronski_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Marcin Witkowski",
						Number = 40,
						Position = PlayerPosition.CircleRunner,
						Nationality = "Polska",
						BirthDate = "17.03.2003",
						Height = 0,
						Weight = 0,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.marcin_witkowski.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.marcin_witkowski_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Filip Wadowski",
						Number = 22,
						Position = PlayerPosition.CircleRunner,
						Nationality = "Polska",
						BirthDate = "30.04.2000",
						Height = 186,
						Weight = 89,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.filip_wadowski.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.filip_wadowski_face.jpg", assembly)
					});
					break;
				case PositionsMenuItem.MenuItemType.Wingers:
					players.Add(
					new Player
					{
						Name = "Mateusz Krasucki",
						Number = 16,
						Position = PlayerPosition.Winger,
						Nationality = "Polska",
						BirthDate = "11.12.1999",
						Height = 181,
						Weight = 75,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.mateusz_krasucki.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.mateusz_krasucki_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Maxymilian Pasierb",
						Number = 19,
						Position = PlayerPosition.Winger,
						Nationality = "Polska",
						BirthDate = "N/A",
						Height = 0,
						Weight = 0,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.maxymilian_pasierb.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.maxymilian_pasierb_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Kamil Głos",
						Number = 20,
						Position = PlayerPosition.Winger,
						Nationality = "Polska",
						BirthDate = "N/A",
						Height = 0,
						Weight = 0,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.kamil_glos.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.kamil_glos_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Dawid Skoczylas",
						Number = 14,
						Position = PlayerPosition.Winger,
						Nationality = "Polska",
						BirthDate = "25.09.1995",
						Height = 170,
						Weight = 75,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.dawid_skoczylas.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.dawid_skoczylas_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Łukasz Dudek",
						Number = 9,
						Position = PlayerPosition.Winger,
						Nationality = "Polska",
						BirthDate = "18.08.2000",
						Height = 175,
						Weight = 78,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.lukasz_dudek.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.lukasz_dudek_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Patryk Madeja",
						Number = 6,
						Position = PlayerPosition.Winger,
						Nationality = "Polska",
						BirthDate = "05.01.1995",
						Height = 178,
						Weight = 75,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.patryk_madeja.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.patryk_madeja_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Bartosz Hardzina",
						Number = 7,
						Position = PlayerPosition.Winger,
						Nationality = "Polska",
						BirthDate = "16.01.2001",
						Height = 184,
						Weight = 79,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.bartosz_hardzina.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.bartosz_hardzina_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Tomasz Kowal",
						Number = 13,
						Position = PlayerPosition.Winger,
						Nationality = "Polska",
						BirthDate = "N/A",
						Height = 184,
						Weight = 79,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.tomasz_kowal.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.tomasz_kowal_face.jpg", assembly)
					});
					players.Add(
					new Player
					{
						Name = "Bartosz Skoczylas",
						Number = 3,
						Position = PlayerPosition.Winger,
						Nationality = "Polska",
						BirthDate = "17.10.2003",
						Height = 0,
						Weight = 0,
						PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.Players.bartosz_skoczylas.jpg", assembly),
						IconSource = ImageSource.FromResource("MTSChrzanow.Images.Players.bartosz_skoczylas_face.jpg", assembly)
					});
					break;
				default:
					break;
			}

			return players;
		}
	}
}