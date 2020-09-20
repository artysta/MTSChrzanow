using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class TablePage : ContentPage
	{
		private TableViewModel viewModel;

		public TablePage()
		{
			InitializeComponent();
			viewModel = new TableViewModel(Navigation);
			BindingContext = viewModel;
		}

		void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			// viewModel.GoToGameDetailsCommand.Execute(e.Item as Game);
		}
	}
}
