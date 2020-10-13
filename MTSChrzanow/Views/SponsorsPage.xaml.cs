using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	[DesignTimeVisible(false)]
	public partial class SponsorsPage : ContentPage
	{
		private SponsorsViewModel _viewModel;

		public SponsorsPage()
		{
			InitializeComponent();
			_viewModel = new SponsorsViewModel(Navigation);
			BindingContext = _viewModel;
		}

		void ListView_ItemTapped(object sender, ItemTappedEventArgs e) =>
			_viewModel.GoToSelectedSponsor.Execute(e.Item as Sponsor);
	}
}
