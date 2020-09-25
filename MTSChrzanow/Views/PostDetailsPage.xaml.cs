using MTSChrzanow.Models;
using MTSChrzanow.ViewModels;
using System.ComponentModel;
using System.Web;
using Xamarin.Forms;

namespace MTSChrzanow.Views
{
	[DesignTimeVisible(false)]
	public partial class PostDetailsPage : ContentPage
	{
		private PostDetailsViewModel _viewModel;

		public PostDetailsPage(MTSPost post)
		{
			InitializeComponent();

			if (post != null)
			{
				_viewModel = new PostDetailsViewModel(post);
				BindingContext = _viewModel;
				Title = HttpUtility.HtmlDecode(post.Title.Rendered);
			}
		}

		private void Button_Clicked(object sender, System.EventArgs e)
		{
			_viewModel.GoToDetailsCommand.Execute(null);
		}
	}
}
