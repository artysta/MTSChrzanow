using MTSChrzanow.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	[DesignTimeVisible(false)]
	public partial class UserProfilePage : ContentPage
	{
		private UserProfileViewModel _viewModel;

		public UserProfilePage()
		{
			InitializeComponent();
			_viewModel = new UserProfileViewModel();
			BindingContext = _viewModel;
		}

		private void Logout_Button_Clicked(object sender, System.EventArgs e) =>
			_viewModel.LogoutCommand.Execute(null);
	}
}
