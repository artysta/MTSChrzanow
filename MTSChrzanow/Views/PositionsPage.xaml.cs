using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	[DesignTimeVisible(false)]
	public partial class PositionsPage : ContentPage
	{
		private PositionsViewModel _viewModel;

		public PositionsPage()
		{
			InitializeComponent();
			_viewModel = new PositionsViewModel(Navigation);
			BindingContext = _viewModel;
		}

		void ListView_ItemTapped(object sender, ItemTappedEventArgs e) =>
			_viewModel.GoToSelectedPage.Execute(e.Item as PositionsMenuItem);
	}
}
