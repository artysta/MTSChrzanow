using MTSChrzanow.Models;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	public class PostDetailsViewModel : BaseViewModel
	{
		private ICommand _openPostInBrowserCommand;
		public ICommand GoToDetailsCommand => _openPostInBrowserCommand ?? (_openPostInBrowserCommand = new Command(OnObenPostInBrowser));
		private MTSPost _mtsPost;
		public MTSPost MTSPost
		{
			get => _mtsPost;
			set
			{
				SetProperty(ref _mtsPost, value);
			}
		}

		public PostDetailsViewModel() { }

		public PostDetailsViewModel(MTSPost post)
		{
			MTSPost = post;
			Android.Util.Log.Debug("DETAILS_PAGE", post.Title.Rendered);
		}

		private async void OnObenPostInBrowser()
		{
			await Launcher.OpenAsync(MTSPost.Link);
		}
	}
}
