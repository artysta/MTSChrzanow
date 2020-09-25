using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	[DesignTimeVisible(false)]
	public partial class RealtimeGamePage : ContentPage
	{
		private RealtimeGameViewModel _viewModel;

		public RealtimeGamePage()
		{
			InitializeComponent();
			_viewModel = new RealtimeGameViewModel();
			BindingContext = _viewModel;
		}
	}
}
