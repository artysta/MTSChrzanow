using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using MTSChrzanow.Views;

namespace MTSChrzanow
{
	public partial class App : Application
	{
		public static string MTSChrzanowApiUrl { get; private set; }
		public static string MTSChrzanowApiPostsUrl { get; private set; }
		public static string MTSChrzanowApiPostsFromPageUrl { get; private set; }

		public App()
		{
			InitializeComponent();
			InitializeApp();
		}

		private async Task InitializeApp()
		{
			await LoadConfig();
			MainPage = new NavigationPage(new MainPage());
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
