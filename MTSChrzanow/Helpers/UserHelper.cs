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

		public async static void SaveUserAsync(User user)
		{
			await SecureStorage.SetAsync(USER_EMAIL_KEY, user.Email);
			await SecureStorage.SetAsync(USER_PASSWORD_KEY, user.Password);
		}
		public static void RemoveUser()
		{
			SecureStorage.Remove(USER_EMAIL_KEY);
			SecureStorage.Remove(USER_PASSWORD_KEY);
		}

		public async static Task<User> GetUserAsync()
		{
			string email = await GetUserEmailAsync();
			string password = await GetUserPasswordAsync();
			return new User(email, password);
		}

		public async static Task<string> GetUserEmailAsync() => await SecureStorage.GetAsync(USER_EMAIL_KEY);
		public async static Task<string> GetUserPasswordAsync() => await SecureStorage.GetAsync(USER_PASSWORD_KEY);

		// Authenticate user & return access token.
		public async static Task<string> LoginUser(string email, string password)
		{
			IFirebaseAuthenticator auth = DependencyService.Get<IFirebaseAuthenticator>();
			return auth == null ? null : await auth.LoginWithEmailPassword(email, password);
		}

		// Sign up user & return access token.
		public async static Task<string> RegisterUser(string email, string password)
		{
			IFirebaseAuthenticator auth = DependencyService.Get<IFirebaseAuthenticator>();
			return await auth.SignupWithEmailPassword(email, password);
		}

		// Check if there is user email saved in the secure storage.
		public async static Task<bool> UserExists() => string.IsNullOrWhiteSpace(await GetUserPasswordAsync()) ? false : true;

		public static string GetUserID()
		{
			IFirebaseAuthenticator auth = DependencyService.Get<IFirebaseAuthenticator>();
			return auth.GetCurrentUserID();
		}

		public async static Task<string> GetAccessTokenAsync() => await LoginUser(App.ViewModel.LoggedUser.Email, App.ViewModel.LoggedUser.Password);
	
		public static void ResetPassword(string email)
		{
			IFirebaseAuthenticator auth = DependencyService.Get<IFirebaseAuthenticator>();
			auth.ResetPassword(email);
		}
	}
}
