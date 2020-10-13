using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	[DesignTimeVisible(false)]
	public partial class PlayerDetailsPage : ContentPage
	{
		public PlayerDetailsPage(Player player)
		{
			InitializeComponent();

			if (player != null)
			{
				BindingContext = new PlayerDetailsViewModel(player);
			}
		}
	}
}
