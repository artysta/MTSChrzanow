using MTSChrzanow.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MTSChrzanow.Helpers
{
	public class UserHelper
	{
		private static readonly string USER_EMAIL_KEY = "USER_EMAIL";
		private static readonly string USER_PASSWORD_KEY = "USER_PASSWORD";
		private static readonly string USER_TOKEN_KEY = "USER_TOKEN";

		public async static void SaveUserAsync(User user)
		{
			await SecureStorage.SetAsync(USER_EMAIL_KEY, user.Email);
			await SecureStorage.SetAsync(USER_PASSWORD_KEY, user.Password);
			await SecureStorage.SetAsync(USER_TOKEN_KEY, user.Token);
		}
		public static void RemoveUser()
		{
			SecureStorage.Remove(USER_EMAIL_KEY);
			SecureStorage.Remove(USER_PASSWORD_KEY);
			SecureStorage.Remove(USER_TOKEN_KEY);
		}

		public async static Task<User> GetUserAsync()
		{
			string email = await SecureStorage.GetAsync(USER_EMAIL_KEY);
			string password = await SecureStorage.GetAsync(USER_PASSWORD_KEY);
			string token = await SecureStorage.GetAsync(USER_TOKEN_KEY);
			return new User() { Email = email, Password = password, Token = token};
		}
		
		// Returns auth token.
		public async static Task<string> LoginUser(string email, string password)
		{
			IFirebaseAuthenticator auth = DependencyService.Get<IFirebaseAuthenticator>();
			return auth == null ? null : await auth.LoginWithEmailPassword(email, password);
		}

		public async static void RefreshToken()
		{
			App.ViewModel.LoggedUser.Token = await LoginUser(App.ViewModel.LoggedUser.Email, App.ViewModel.LoggedUser.Password);
		}

		// Check if there is user email saved in the storage.
		public async static Task<bool> UserExists()
		{
			return string.IsNullOrWhiteSpace(await SecureStorage.GetAsync(USER_EMAIL_KEY)) ? false : true;
		}
	}
}
