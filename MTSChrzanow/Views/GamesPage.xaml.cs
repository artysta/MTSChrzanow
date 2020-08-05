using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class GamesPage : ContentPage
	{
		private GamesViewModel viewModel;

		public GamesPage()
		{
			InitializeComponent();
			viewModel = new GamesViewModel(Navigation);
			BindingContext = viewModel;
		}

		void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			viewModel.GoToGameDetailsCommand.Execute(e.Item as Game);
		}
	}
}
