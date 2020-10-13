using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	[DesignTimeVisible(false)]
	public partial class PlayersPage : ContentPage
	{
		private PlayersViewModel _viewModel;

		public PlayersPage(PositionsMenuItem position)
		{
			InitializeComponent();

			if (position != null){
				_viewModel = new PlayersViewModel(Navigation, position);
				BindingContext = _viewModel;
			}
		}

		public void ListView_ItemTapped(object sender, ItemTappedEventArgs e) =>
			_viewModel.GoToPlayerDetailsCommand.Execute(e.Item as Player);
	}
}
