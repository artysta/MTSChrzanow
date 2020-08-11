using MTSChrzanow.Views;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace MTSChrzanow.Models
{
    public class MTSPlayersData
    {
        public static List<MTSPlayer> GetPlayers(PositionsMenuItem.MenuItemType position)
        {
            List<MTSPlayer> players = new List<MTSPlayer>();
            Assembly assembly = typeof(PlayerDetailsPage).GetTypeInfo().Assembly;

            switch (position)
            {
                case PositionsMenuItem.MenuItemType.Goalkeepers:
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Patryk Rolewicz",
                        Number = 1,
                        Position = MTSPlayerPosition.Goalkeeper,
                        Nationality = "Polska",
                        BirthDate = "07.10.2000",
                        Height = 193,
                        Weight = 90,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Marcin Górkowski",
                        Number = 32,
                        Position = MTSPlayerPosition.Goalkeeper,
                        Nationality = "Polska",
                        BirthDate = "02.01.1996",
                        Height = 178,
                        Weight = 102,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Grzegorz Małodobry",
                        Number = 98,
                        Position = MTSPlayerPosition.Goalkeeper,
                        Nationality = "Polska",
                        BirthDate = "05.12.1998",
                        Height = 182,
                        Weight = 105,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    break;
                case PositionsMenuItem.MenuItemType.Fullbacks:
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Karol Put",
                        Number = 5,
                        Position = MTSPlayerPosition.Fullback,
                        Nationality = "Polska",
                        BirthDate = "29.03.1999",
                        Height = 181,
                        Weight = 85,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Patryk Rola",
                        Number = 8,
                        Position = MTSPlayerPosition.Fullback,
                        Nationality = "Polska",
                        BirthDate = "07.06.1995",
                        Height = 188,
                        Weight = 89,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Marcin Skoczylas",
                        Number = 27,
                        Position = MTSPlayerPosition.Fullback,
                        Nationality = "Polska",
                        BirthDate = "01.09.1983",
                        Height = 189,
                        Weight = 95,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Sebastian Danysz",
                        Number = 24,
                        Position = MTSPlayerPosition.Fullback,
                        Nationality = "Polska",
                        BirthDate = "16.03.1993",
                        Height = 191,
                        Weight = 93,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Jakub Romian",
                        Number = 88,
                        Position = MTSPlayerPosition.Fullback,
                        Nationality = "Polska",
                        BirthDate = "27.01.1997",
                        Height = 188,
                        Weight = 83,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Kacper Węgrzyn",
                        Number = 4,
                        Position = MTSPlayerPosition.Fullback,
                        Nationality = "Polska",
                        BirthDate = "08.01.1999",
                        Height = 179,
                        Weight = 74,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Jan Orlicki",
                        Number = 18,
                        Position = MTSPlayerPosition.Fullback,
                        Nationality = "Polska",
                        BirthDate = "02.06.1996",
                        Height = 178,
                        Weight = 82,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    break;
                case PositionsMenuItem.MenuItemType.CircleRunners:
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Michał Olszewik",
                        Number = 15,
                        Position = MTSPlayerPosition.CircleRunner,
                        Nationality = "Polska",
                        BirthDate = "01.08.1997",
                        Height = 180,
                        Weight = 80,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Adrian Danysz",
                        Number = 3,
                        Position = MTSPlayerPosition.CircleRunner,
                        Nationality = "Polska",
                        BirthDate = "22.01.1998",
                        Height = 192,
                        Weight = 100,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Paweł Stroński",
                        Number = 25,
                        Position = MTSPlayerPosition.CircleRunner,
                        Nationality = "Polska",
                        BirthDate = "04.07.1992",
                        Height = 188,
                        Weight = 85,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    break;
                case PositionsMenuItem.MenuItemType.Wingers:
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Mateusz Krasucki",
                        Number = 16,
                        Position = MTSPlayerPosition.Winger,
                        Nationality = "Polska",
                        BirthDate = "11.12.1999",
                        Height = 181,
                        Weight = 75,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Maxymilian Pasierb",
                        Number = 19,
                        Position = MTSPlayerPosition.Winger,
                        Nationality = "Polska",
                        BirthDate = "N/A",
                        Height = 0,
                        Weight = 0,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Kamil Głos",
                        Number = 20,
                        Position = MTSPlayerPosition.Winger,
                        Nationality = "Polska",
                        BirthDate = "N/A",
                        Height = 0,
                        Weight = 0,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Dawid Skoczylas",
                        Number = 14,
                        Position = MTSPlayerPosition.Winger,
                        Nationality = "Polska",
                        BirthDate = "25.09.1995",
                        Height = 170,
                        Weight = 75,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Konrad Łuczyński",
                        Number = 11,
                        Position = MTSPlayerPosition.Winger,
                        Nationality = "Polska",
                        BirthDate = "N/A",
                        Height = 0,
                        Weight = 0,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Łukasz Dudek",
                        Number = 9,
                        Position = MTSPlayerPosition.Winger,
                        Nationality = "Polska",
                        BirthDate = "18.08.2000",
                        Height = 175,
                        Weight = 78,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Patryk Madeja",
                        Number = 6,
                        Position = MTSPlayerPosition.Winger,
                        Nationality = "Polska",
                        BirthDate = "05.01.1995",
                        Height = 178,
                        Weight = 75,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    players.Add(
                    new MTSPlayer
                    {
                        Name = "Bartosz Hardzina",
                        Number = 7,
                        Position = MTSPlayerPosition.Winger,
                        Nationality = "Polska",
                        BirthDate = "16.01.2001",
                        Height = 184,
                        Weight = 79,
                        PhotoSource = ImageSource.FromResource("MTSChrzanow.Images.logo_xamarin.png", assembly)
                    });
                    break;
                default:
                    break;
            }

            return players;
        }
    }
}