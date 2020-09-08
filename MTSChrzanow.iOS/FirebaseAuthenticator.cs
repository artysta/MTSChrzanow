using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Auth;
using MTSChrzanow.iOS;

[assembly: Dependency(typeof(FirebaseAuthenticator))]
namespace MTSChrzanow.iOS
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var authDataResult = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
            return await authDataResult.User.GetIdTokenAsync();
        }

        public async Task<string> SignupWithEmailPassword(string email, string password)
        {
            var authDataResult = await Auth.DefaultInstance.CreateUserAsync(email, password);
            return await authDataResult.User.GetIdTokenAsync();
        }
    }
}