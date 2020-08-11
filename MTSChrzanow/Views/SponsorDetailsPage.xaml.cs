using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class SponsorDetailsPage : ContentPage
	{
		private SponsorDetailsViewModel viewModel;
		private MTSSponsor _sponsor;

		public SponsorDetailsPage(MTSSponsor sponsor)
		{
			_sponsor = sponsor;
			InitializeComponent();
			viewModel = new SponsorDetailsViewModel(_sponsor);
			BindingContext = viewModel;
		}

		private void Button_Clicked(object sender, System.EventArgs e)
		{
			viewModel.GoToDetailsCommand.Execute(_sponsor);
		}
	}
}
