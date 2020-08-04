using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class SponsorsPage : ContentPage
	{
		private SponsorsViewModel viewModel;

		public SponsorsPage()
		{
			InitializeComponent();
			viewModel = new SponsorsViewModel(Navigation);
			BindingContext = viewModel;
		}

		void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			viewModel.GoToSelectedSponsor.Execute(e.Item as MTSSponsor);
		}
	}
}
