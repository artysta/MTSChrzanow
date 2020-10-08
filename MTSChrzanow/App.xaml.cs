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
		public static string ApiUrl { get; private set; }
		public static string ApiPostsUrl { get; private set; }
		public static string ApiPostsFromPageUrl { get; private set; }
		public static string ApiSinglePostMedia { get; private set; }
		public static string ApiFirebaseUrl { get; private set; }
		public static string ApiFirebaseGamesUrl { get; private set; }
		public static string ApiRealTimeGameChild { get; private set; }
		public static string ApiFirebaseAuth { get; private set; }
		public static string ApiWPTotalPages { get; private set; }
		public static string ApiFirebaseTableUrl { get; private set; }

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
					ApiUrl = dynamicJson["ApiUrl"].Value<string>();
					ApiPostsUrl = dynamicJson["ApiPostsUrl"].Value<string>();
					ApiPostsFromPageUrl = dynamicJson["ApiPostsFromPageUrl"].Value<string>();
					ApiSinglePostMedia = dynamicJson["ApiSinglePostMedia"].Value<string>();
					ApiFirebaseUrl = dynamicJson["ApiFirebaseUrl"].Value<string>();
					ApiFirebaseGamesUrl = dynamicJson["ApiFirebaseGamesUrl"].Value<string>();
					ApiRealTimeGameChild = dynamicJson["ApiRealTimeGameChild"].Value<string>();
					ApiFirebaseAuth = dynamicJson["ApiFirebaseAuth"].Value<string>();
					ApiWPTotalPages = dynamicJson["ApiWPTotalPages"].Value<string>();
					ApiFirebaseTableUrl = dynamicJson["ApiFirebaseTableUrl"].Value<string>();
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
