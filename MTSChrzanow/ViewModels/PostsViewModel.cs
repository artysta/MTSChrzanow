using MTSChrzanow.Helpers;
using MTSChrzanow.Models;
using MTSChrzanow.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MTSChrzanow.ViewModels
{
	class PostsViewModel : BaseViewModel
	{
		private INavigation _navigation;

		private ICommand _goToDetailsCommand;
		public ICommand GoToDetailsCommand => _goToDetailsCommand ?? (_goToDetailsCommand = new Command<MTSPost>(OnGoToDetails));

		private ICommand _pickerSelectionChanged;
		public ICommand PickerSelectionChanged => _pickerSelectionChanged ?? (_pickerSelectionChanged = new Command<int>(OnSelectionChanged));

		private ObservableCollection<MTSPost> _mtsPosts;
		public ObservableCollection<MTSPost> MTSPosts
		{
			get => _mtsPosts;
			set => SetProperty(ref _mtsPosts, value);
		}

		private ObservableCollection<string> _pagePickerItems;
		public ObservableCollection<string> PagePickerItems
		{
			get => _pagePickerItems;
			set => SetProperty(ref _pagePickerItems, value);
		}
		
		private bool _isBusy;
		public bool IsBusy
		{
			get => _isBusy;
			set => SetProperty(ref _isBusy, value);
		}

		private bool _isBusyFirstLoad;
		public bool IsBusyFristLoad
		{
			get => _isBusyFirstLoad;
			set => SetProperty(ref _isBusyFirstLoad, value);
		}

		public PostsViewModel(INavigation navigation)
		{
			_navigation = navigation;
			InitializePages();
		}

		private void SetPosts(List<MTSPost> posts)
		{
			if (posts != null)
			{
				MTSPosts = new ObservableCollection<MTSPost>(posts);
			}
		}

		// Initialize pages when te app starts.
		private async Task InitializePages()
		{
			IsBusy = IsBusyFristLoad = true;
			WebClient client = new WebClient();
			string query = QueryBuilder.CreateQuery(App.ApiUrl, App.ApiPostsUrl);
			string json = await client.DownloadStringTaskAsync(query);

			// Deserialize blog posts.
			var posts = JsonConvert.DeserializeObject<List<MTSPost>>(json);

			// Get total amount of pages and initialize picker values.
			WebHeaderCollection headers = client.ResponseHeaders;
			int totalPages = int.Parse(headers[App.ApiWPTotalPages]);
			SetPickerItemsValues(totalPages);

			SetPosts(posts);
			GetPostsMedia();
			IsBusy = IsBusyFristLoad = false;
		}

		private async Task GetPostsFromPage(int pageNumber)
		{
			IsBusy = true;

			string query = QueryBuilder.CreateQuery
				(
					App.ApiUrl,
					App.ApiPostsFromPageUrl,
					pageNumber.ToString()
				);

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
				string query = QueryBuilder.CreateQuery
					(
						App.ApiUrl,
						App.ApiSinglePostMedia,
						p.FeaturedMedia.ToString()
					);

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

		private async void OnGoToDetails(MTSPost item)
		{
			if (item != null)
			{
				await _navigation.PushAsync(new PostDetailsPage(item));
			}
		}

		private void OnSelectionChanged(int selectedPage)
		{
			GetPostsFromPage(selectedPage + 1);
		}
	}
}
