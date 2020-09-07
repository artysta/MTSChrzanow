using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class LoginPage : ContentPage
	{
		private LoginViewModel _viewModel;
		public LoginPage()
		{
			InitializeComponent();
			_viewModel = new LoginViewModel(Navigation);
			BindingContext = _viewModel;
		}

		private void Login_Button_Clicked(object sender, System.EventArgs e)
		{
			DisplayAlert("Logowanie", "Pomyślnie zalogowano do konta!", "Ok");
			_viewModel.LoginCommand.Execute(null);
		}

		private void Register_Button_Clicked(object sender, System.EventArgs e)
		{
			_viewModel.GoToRegisterCommand.Execute(null);
		}
	}
}
