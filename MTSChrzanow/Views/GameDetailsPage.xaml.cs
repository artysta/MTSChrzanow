using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	[DesignTimeVisible(false)]
	public partial class GameDetailsPage : ContentPage
	{
		public GameDetailsPage(Game game)
		{
			InitializeComponent();

			if (game != null)
			{
				BindingContext = new GameDetailsViewModel(game);
			}
		}
	}
}
