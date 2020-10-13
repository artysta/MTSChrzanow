using MTSChrzanow.Models;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	public class BlogPostDetailsViewModel : BaseViewModel
	{
		private ICommand _openPostInBrowserCommand;
		public ICommand GoToDetailsCommand => _openPostInBrowserCommand ?? (_openPostInBrowserCommand = new Command(OnObenPostInBrowser));
		
		private BlogPost _post;
		public BlogPost BlogPost
		{
			get => _post;
			set => SetProperty(ref _post, value);
		}

		public BlogPostDetailsViewModel(BlogPost post)
		{
			if (post != null)
			{
				BlogPost = post;
			}
		}

		private async void OnObenPostInBrowser()
		{
			if (string.IsNullOrWhiteSpace(BlogPost.Link))
			{
				await Application.Current.MainPage.DisplayAlert("Uwaga!", "Nie udało się otworzyć artykułu w przeglądarce!", "Ok");
			}
			else
			{
				await Launcher.OpenAsync(BlogPost.Link);
			}
		}
	}
}
