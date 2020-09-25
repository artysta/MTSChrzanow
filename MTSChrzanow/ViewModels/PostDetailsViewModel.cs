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
			set => SetProperty(ref _mtsPost, value);
		}

		public PostDetailsViewModel(MTSPost post)
		{
			if (post != null)
			{
				MTSPost = post;
			}
		}

		private async void OnObenPostInBrowser()
		{
			if (string.IsNullOrWhiteSpace(MTSPost.Link))
			{
				await Application.Current.MainPage.DisplayAlert("Uwaga!", "Nie udało się otworzyć artykułu w przeglądarce!", "Ok");
			}
			else
			{
				await Launcher.OpenAsync(MTSPost.Link);
			}
		}
	}
}
