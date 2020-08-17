using MTSChrzanow.Models;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using MTSChrzanow.Views;
using System;
using System.Threading.Tasks;

namespace MTSChrzanow.ViewModels
{
	class PostsViewModel : BaseViewModel
	{
		private bool _isBusy;
		private bool _isFirstBusy;
		private ObservableCollection<MTSPost> _mtsPosts;
		private ObservableCollection<string> _pagePickerItems;
		private INavigation _navigation;
		private ICommand _goToDetailsCommand;
		private ICommand _pickerSelectionChanged;

		public ICommand GoToDetailsCommand => _goToDetailsCommand ?? (_goToDetailsCommand = new Command<MTSPost>(OnGoToDetails));
		public ICommand PickerSelectionChanged => _pickerSelectionChanged ?? (_pickerSelectionChanged = new Command<int>(OnSelectionChanged));

		public ObservableCollection<MTSPost> MTSPosts
		{
			get { return _mtsPosts; }
			set
			{
				SetProperty(ref _mtsPosts, value);
			}
		}

		public ObservableCollection<string> PagePickerItems
		{
			get { return _pagePickerItems; }
			set
			{
				SetProperty(ref _pagePickerItems, value);
			}
		}
		
		public bool IsBusy
		{
			get { return _isBusy; }
			set
			{
				SetProperty(ref _isBusy, value);
			}
		}
		
		public bool IsBusyFristLoad
		{
			get { return _isFirstBusy; }
			set
			{
				SetProperty(ref _isFirstBusy, value);
			}
		}

		public PostsViewModel() { }

		public PostsViewModel(INavigation navigation)
		{
			_navigation = navigation;
			InitializePages();
		}

		private void SetPosts(List<MTSPost> posts)
		{
			if (posts != null) MTSPosts = new ObservableCollection<MTSPost>(posts);
		}

		// Initialize pages when te app starts.
		private async Task InitializePages()
		{
			IsBusy = IsBusyFristLoad = true;
			WebClient client = new WebClient();
			string query = GetQuery(App.MTSChrzanowApiUrl, App.MTSChrzanowApiPostsUrl);
			string json = await client.DownloadStringTaskAsync(query);

			// Deserialize blog posts.
			var posts = JsonConvert.DeserializeObject<List<MTSPost>>(json);

			// Get total amount of pages and initialize picker values.
			WebHeaderCollection headers = client.ResponseHeaders;
			int totalPages = int.Parse(headers["X-WP-TotalPages"]);
			SetPickerItemsValues(totalPages);

			SetPosts(posts);
			GetPostsMedia();
			IsBusy = IsBusyFristLoad = false;
		}

		private async Task GetPostsFromPage(int pageNumber)
		{
			IsBusy = true;
			string query = GetQuery(App.MTSChrzanowApiUrl, App.MTSChrzanowApiPostsFromPageUrl, pageNumber.ToString());
			string json = await new WebClient().DownloadStringTaskAsync(query);

			// Deserialize blog posts.
			var posts = JsonConvert.DeserializeObject<List<MTSPost>>(json);
			SetPosts(posts);
			GetPostsMedia();
			IsBusy = false;
		}

		private async Task GetPostsMedia()
		{
			WebClient client = new WebClient();
			
			foreach (MTSPost p in MTSPosts)
			{
				string query = GetQuery(App.MTSChrzanowApiUrl, App.MTSChrzanowApiSinglePostMedia, p.FeaturedMedia.ToString());
				System.Diagnostics.Debug.WriteLine("Query for post id " + p.Id + ": " + query);

				try
				{
					string json = await client.DownloadStringTaskAsync(query);
					MTSPostMedia media = JsonConvert.DeserializeObject<MTSPostMedia>(json);

					// There is problem to pass uri's that starts with "http" as image source at this moment so... replace "http" to "https".
					p.ImageSource = media.Guid.Rendered.StartsWith("http:") ? media.Guid.Rendered.Replace("http:", "https:")
																				: media.Guid.Rendered;
				}
				catch (Exception e)
				{
					// Assign default image if sth went wrong.
					p.ImageSource = "https://mtschrzanow.pl/wp-content/uploads/2019/01/logokolor.png";
					System.Diagnostics.Debug.WriteLine(e.Message);
				}

				System.Diagnostics.Debug.WriteLine("Post title: " + p.Title + ", image source: " + p.ImageSource + ", media id: " + p.FeaturedMedia);
			}

			return;
		}

		private void SetPickerItemsValues(int k)
		{
			List<string> items = new List<string>();

			for (int i = 0; i < k; i++)
			{
				items.Add("Strona " + (i + 1));
			}

			PagePickerItems = new ObservableCollection<string>(items);
		}

		private string GetQuery(params string[] list)
		{
			StringBuilder sb = new StringBuilder();
			foreach (string s in list) sb.Append(s);
			return sb.ToString();
		}

		private async void OnGoToDetails(MTSPost item)
		{
			await _navigation.PushAsync(new PostDetailsPage(item));
		}

		private void OnSelectionChanged(int selectedPage)
		{
			GetPostsFromPage(selectedPage + 1);
		}
	}
}
