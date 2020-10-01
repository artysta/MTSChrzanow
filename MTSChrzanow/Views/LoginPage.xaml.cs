using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
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

		private void Login_Button_Clicked(object sender, System.EventArgs e) =>
			_viewModel.LoginCommand.Execute(null);

		private void Register_Button_Clicked(object sender, System.EventArgs e) =>
			_viewModel.GoToRegisterCommand.Execute(null);

		private void Reset_Password_Button_Clicked(object sender, System.EventArgs e) =>
			_viewModel.ResetPasswordCommand.Execute(null);
	}
}
