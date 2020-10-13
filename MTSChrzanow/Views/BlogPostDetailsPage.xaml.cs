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
		private BlogPostDetailsViewModel _viewModel;

		public PostDetailsPage(BlogPost post)
		{
			InitializeComponent();

			if (post != null)
			{
				_viewModel = new BlogPostDetailsViewModel(post);
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
