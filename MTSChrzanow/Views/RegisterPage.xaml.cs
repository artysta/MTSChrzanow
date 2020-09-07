using System.ComponentModel;
using Xamarin.Forms;
using MTSChrzanow.ViewModels;

namespace MTSChrzanow.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class RegisterPage : ContentPage
	{
		private RegisterViewModel _viewModel;
		public RegisterPage()
		{
			InitializeComponent();
			_viewModel = new RegisterViewModel(Navigation);
			BindingContext = _viewModel;
		}

		private void Register_Button_Clicked(object sender, System.EventArgs e)
		{
			DisplayAlert("Rejestracja", "Pomyślnie utworzono konto!", "Ok");
			_viewModel.LoginCommand.Execute(null);
		}
	}
}
