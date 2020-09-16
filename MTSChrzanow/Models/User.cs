namespace MTSChrzanow.Models
{
	public class User
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string Token { get; set; }

		public User(string email, string password)
		{
			Email = email;
			Password = password;
		}
	}
}
