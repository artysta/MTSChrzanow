using Android.Webkit;
using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class PlayersPage : ContentPage
	{
		private PlayersViewModel viewModel;

		public PlayersPage(PositionsMenuItem position)
		{
			InitializeComponent();
			viewModel = new PlayersViewModel(Navigation, position);
			BindingContext = viewModel;
		}

		void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			viewModel.GoToPlayerDetailsCommand.Execute(e.Item as MTSPlayer);
		}
	}
}
