using Xamarin.Forms;

namespace MTSChrzanow.Models
{
	public class MTSSponsor
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public string Street { get; set; }
		public string PhoneNumber { get; set; }
		public string Mail { get; set; }
		public string WebSite { get; set; }
		public ImageSource LogoSource { get; set; }
		public override string ToString() => $"{ Name }, { Description }, { City }, { PostalCode }, { Street }, { PhoneNumber }, { Mail }, { WebSite }.";
	}
}
