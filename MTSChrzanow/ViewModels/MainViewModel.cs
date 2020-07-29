using MTSChrzanow.Models;
using System.Collections.ObjectModel;
using System.Net;
using Android.Util;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using MTSChrzanow.Views;
using Android.Content.Res;

namespace MTSChrzanow.ViewModels
{
	class MainViewModel : BaseViewModel
	{
		private INavigation _navigation;
		private ObservableCollection<MTSPost> _mtsPosts;
		private ICommand _goToDetailsCommand;
		
		public ICommand GoToDetailsCommand => _goToDetailsCommand ?? (_goToDetailsCommand = new Command<MTSPost>(OnGoToDetails));

		private async void OnGoToDetails(MTSPost item)
		{
			await _navigation.PushAsync(new DetailsPage(item));
		}

		public ObservableCollection<MTSPost> MTSPosts
		{
			get { return _mtsPosts; }
			set
			{
				SetProperty(ref _mtsPosts, value);
			}
		}

		public MainViewModel(INavigation navigation)
		{
			_navigation = navigation;
			MTSPosts = new ObservableCollection<MTSPost>(GetPosts());
		}

		private List<MTSPost> GetPosts()
		{
			Log.Debug("JSON_POST", "Reading json...");
			string query = GetQuery(App.MTSChrzanowApiUrl, App.MTSChrzanowApiPostsUrl);
			string json = new WebClient().DownloadString(query);
			Log.Debug("JSON_POST", json);
			
			// Deserialize blog posts.
			var posts = JsonConvert.DeserializeObject<List<MTSPost>>(json);
			return posts;
		}

		private string GetQuery(params string[] list)
		{
			StringBuilder sb = new StringBuilder();
			foreach (string s in list) sb.Append(s);
			return sb.ToString();
		}
	}
}
