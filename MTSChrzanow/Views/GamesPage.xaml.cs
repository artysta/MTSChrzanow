using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	[DesignTimeVisible(false)]
	public partial class GamesPage : ContentPage
	{
		private GamesViewModel _viewModel;

		public GamesPage()
		{
			InitializeComponent();
			_viewModel = new GamesViewModel(Navigation);
			BindingContext = _viewModel;
		}

		void ListView_ItemTapped(object sender, ItemTappedEventArgs e) =>
			_viewModel.GoToGameDetailsCommand.Execute(e.Item as Game);
	}
}
