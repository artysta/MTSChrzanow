using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	[DesignTimeVisible(false)]
	public partial class SponsorDetailsPage : ContentPage
	{
		private SponsorDetailsViewModel _viewModel;
		private Sponsor _sponsor;

		public SponsorDetailsPage(Sponsor sponsor)
		{
			InitializeComponent();
			
			if (sponsor != null)
			{
				_sponsor = sponsor;
				_viewModel = new SponsorDetailsViewModel(_sponsor);
				BindingContext = _viewModel;
			}
		}

		private void Button_Clicked(object sender, System.EventArgs e) =>
			_viewModel.GoToDetailsCommand.Execute(_sponsor);
	}
}
