using MTSChrzanow.Helpers;
using MTSChrzanow.ViewModels;
using MTSChrzanow.Views;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MTSChrzanow
{
	public partial class App : Application
	{
		public static string MTSChrzanowApiUrl { get; private set; }
		public static string MTSChrzanowApiPostsUrl { get; private set; }
		public static string MTSChrzanowApiPostsFromPageUrl { get; private set; }
		public static string MTSChrzanowApiSinglePostMedia { get; private set; }
		public static string MTSChrzanowFirebaseUrl { get; private set; }
		public static string MTSChrzanowFirebaseGamesUrl { get; private set; }
		public static string MTSChrzanowRealTimeGameChild { get; private set; }
		public static string MTSChrzanowFirebaseAuth { get; private set; }
		public static string MTSChrzanowWPTotalPages { get; private set; }
		public static string MTSChrzanowFirebaseTableUrl { get; private set; }

		public static AppViewModel ViewModel { get; private set; }

		public App()
		{
			InitializeComponent();
			InitializeApp();
		}

		private async Task InitializeApp()
		{
			await LoadConfig();
			ViewModel = new AppViewModel();
			MainPage = await UserHelper.UserExists() ? new NavigationPage(new MainPage())
													 : new NavigationPage(new LoginPage());
		}

		private static async Task LoadConfig()
		{
			var assembly = Assembly.GetAssembly(typeof(App));
			var resourceNames = assembly.GetManifestResourceNames();
			var configName = resourceNames.FirstOrDefault(s => s.Contains("config.json"));

			using (var stream = assembly.GetManifestResourceStream(configName))
			{
				using (var reader = new StreamReader(stream))
				{
					var json = await reader.ReadToEndAsync();
					var dynamicJson = JObject.Parse(json);
					MTSChrzanowApiUrl = dynamicJson["MTSChrzanowApiUrl"].Value<string>();
					MTSChrzanowApiPostsUrl = dynamicJson["MTSChrzanowApiPostsUrl"].Value<string>();
					MTSChrzanowApiPostsFromPageUrl = dynamicJson["MTSChrzanowApiPostsFromPageUrl"].Value<string>();
					MTSChrzanowApiSinglePostMedia = dynamicJson["MTSChrzanowApiSinglePostMedia"].Value<string>();
					MTSChrzanowFirebaseUrl = dynamicJson["MTSChrzanowFirebaseUrl"].Value<string>();
					MTSChrzanowFirebaseGamesUrl = dynamicJson["MTSChrzanowFirebaseGamesUrl"].Value<string>();
					MTSChrzanowRealTimeGameChild = dynamicJson["MTSChrzanowRealTimeGameChild"].Value<string>();
					MTSChrzanowFirebaseAuth = dynamicJson["MTSChrzanowFirebaseAuth"].Value<string>();
					MTSChrzanowWPTotalPages = dynamicJson["MTSChrzanowWPTotalPages"].Value<string>();
					MTSChrzanowFirebaseTableUrl = dynamicJson["MTSChrzanowFirebaseTableUrl"].Value<string>();
				}
			}
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
