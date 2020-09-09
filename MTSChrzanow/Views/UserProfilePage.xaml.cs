using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class UserProfilePage : ContentPage
	{
		private UserProfileViewModel viewModel;

		public UserProfilePage()
		{
			InitializeComponent();
			viewModel = new UserProfileViewModel();
			BindingContext = viewModel;
		}

		private void Logout_Button_Clicked(object sender, System.EventArgs e)
		{
			viewModel.LogoutCommand.Execute(null);
		}
	}
}
