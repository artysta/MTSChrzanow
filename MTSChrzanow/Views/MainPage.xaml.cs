using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		private MainViewModel viewModel;
		public MainPage()
		{
			InitializeComponent();
			viewModel = new MainViewModel(Navigation);
			BindingContext = viewModel;
		}

		private void Button_Clicked(object sender, System.EventArgs e)
		{
			viewModel.GoToPostsCommand.Execute(null);
		}
	}
}
