using System;

namespace MTSChrzanow.Models
{
	public class MTSPost
	{
		public long Id { get; set; }
		public DateTime Date { get; set; }
		public string Link { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string[] Tags { get; set; }
		
		public override string ToString() =>
			$"Id: { Id }, { Date }" +
			$" { Title }" +
			$" { Content }";
	}
}
