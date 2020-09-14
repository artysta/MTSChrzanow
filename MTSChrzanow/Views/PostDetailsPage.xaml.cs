using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using System.Web;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class PostDetailsPage : ContentPage
	{
		private PostDetailsViewModel _viewModel;
		public PostDetailsPage(MTSPost post)
		{
			InitializeComponent();
			_viewModel = new PostDetailsViewModel(post);
			BindingContext = _viewModel;
			Title = HttpUtility.HtmlDecode(post.Title.Rendered);
		}

		private void Button_Clicked(object sender, System.EventArgs e)
		{
			_viewModel.GoToDetailsCommand.Execute(null);
		}
	}
}
