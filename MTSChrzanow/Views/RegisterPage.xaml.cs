using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
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

		private void Register_Button_Clicked(object sender, System.EventArgs e) =>
			_viewModel.RegisterCommand.Execute(null);
	}
}
