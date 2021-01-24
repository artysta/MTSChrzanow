using System.Threading.Tasks;
using Firebase.Auth;
using Xamarin.Forms;
using MTSChrzanow.Droid;
using Android.Gms.Extensions;

[assembly: Dependency(typeof(FirebaseAuthenticator))]
namespace MTSChrzanow.Droid
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var token = await (user.User.GetIdToken(false).AsAsync<GetTokenResult>());
            return token.Token;
        }

        public async Task<string> SignupWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            var token = await (user.User.GetIdToken(false).AsAsync<GetTokenResult>());
            return token.Token;
        }

        public void ResetPassword(string email) => FirebaseAuth.Instance.SendPasswordResetEmail(email);

        public string GetCurrentUserID()
		{
            return FirebaseAuth.Instance.CurrentUser.Uid;
		}
    }
}