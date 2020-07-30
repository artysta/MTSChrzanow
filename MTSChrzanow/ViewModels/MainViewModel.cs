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
		private ICommand _pickerSelectionChanged;

		public ICommand GoToDetailsCommand => _goToDetailsCommand ?? (_goToDetailsCommand = new Command<MTSPost>(OnGoToDetails));
		public ICommand PickerSelectionChanged => _pickerSelectionChanged ?? (_pickerSelectionChanged = new Command<int>(OnSelectionChanged));

		private async void OnGoToDetails(MTSPost item)
		{
			await _navigation.PushAsync(new DetailsPage(item));
		}

		private void OnSelectionChanged(int selectedPage)
		{
			GetPostsFromPage(selectedPage + 1);
		}

		public ObservableCollection<MTSPost> MTSPosts
		{
			get { return _mtsPosts; }
			set
			{
				SetProperty(ref _mtsPosts, value);
			}
		}

		public string[] PagePickerItems { set; get; }

		public MainViewModel() { }

		public MainViewModel(INavigation navigation)
		{
			_navigation = navigation;
			InitializePages();
		}

		private void SetPosts(List<MTSPost> posts)
		{
			if (posts != null) MTSPosts = new ObservableCollection<MTSPost>(posts);
		}

		// Initialize pages when te app starts.
		private void InitializePages()
		{
			WebClient client = new WebClient();
			string query = GetQuery(App.MTSChrzanowApiUrl, App.MTSChrzanowApiPostsUrl);
			string json = client.DownloadString(query);

			// Deserialize blog posts.
			var posts = JsonConvert.DeserializeObject<List<MTSPost>>(json);
			SetPosts(posts);

			// Get total amount of pages and initialize picker values.
			WebHeaderCollection headers = client.ResponseHeaders;
			int totalPages = int.Parse(headers["X-WP-TotalPages"]);
			SetPickerItemsValues(totalPages);
		}

		private void GetPostsFromPage(int pageNumber)
		{
			string query = GetQuery(App.MTSChrzanowApiUrl, App.MTSChrzanowApiPostsFromPageUrl, pageNumber.ToString());
			string json = new WebClient().DownloadString(query);

			// Deserialize blog posts.
			var posts = JsonConvert.DeserializeObject<List<MTSPost>>(json);
			SetPosts(posts);
		}

		private void SetPickerItemsValues(int k)
		{
			PagePickerItems = new string[k];
			for (int i = 0; i < k; i++) PagePickerItems[i] = "Page " + (i + 1);
		}

		private string GetQuery(params string[] list)
		{
			StringBuilder sb = new StringBuilder();
			foreach (string s in list) sb.Append(s);
			return sb.ToString();
		}
	}
}
