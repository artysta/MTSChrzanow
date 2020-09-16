using System.Threading.Tasks;
using Firebase.Auth;
using Xamarin.Forms;
using MTSChrzanow.Droid;

[assembly: Dependency(typeof(FirebaseAuthenticator))]
namespace MTSChrzanow.Droid
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            return token.Token;
        }

        public async Task<string> SignupWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            return token.Token;
        }

        public string GetCurrentUserID()
		{
            return FirebaseAuth.Instance.CurrentUser.Uid;
		}
    }
}