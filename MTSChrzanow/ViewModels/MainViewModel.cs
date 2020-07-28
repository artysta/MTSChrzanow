using MTSChrzanow.Models;
using System.Collections.ObjectModel;
using System.Net;
using Android.Util;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MTSChrzanow.ViewModels
{
	class MainViewModel : BaseViewModel
	{
		ObservableCollection<MTSPost> _mtsPosts;
		public ObservableCollection<MTSPost> MTSPosts
		{
			get { return _mtsPosts; }
			set
			{
				_mtsPosts = value;
				OnPropertyChanged();
			}
		}

		public MainViewModel()
		{
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
