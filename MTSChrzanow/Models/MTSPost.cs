using Newtonsoft.Json;
using System;

namespace MTSChrzanow.Models
{
	public class MTSPost : BaseModel
	{
		[JsonProperty("id")]
		public long Id { get; set; }
		[JsonProperty("date")]
		public DateTime Date { get; set; }
		[JsonProperty("link")]
		public string Link { get; set; }
		[JsonProperty("title")]
		public Title Title { get; set; }
		[JsonProperty("content")]
		public Content Content { get; set; }
		[JsonProperty("tags")]
		public string[] Tags { get; set; }
		[JsonProperty("featured_media")]
		public int FeaturedMedia { get; set; }

		private string _imageSource;
		public string ImageSource
		{
			get => _imageSource;
			set
			{
				this._imageSource = value;
				RaisePropertyChanged("ImageSource");
			}
		}

		public override string ToString() =>
			$"Id: { Id }" +
			$"{ Date }" +
			$" { Title.Rendered }" +
			$" { Content.Rendered }";
	}

	public class Title
	{
		[JsonProperty("rendered")]
		public string Rendered { get; set; }
		[JsonProperty("protected")]
		public bool Protected { get; set; }
	}

	public class Content
	{
		[JsonProperty("rendered")]
		public string Rendered { get; set; }
		[JsonProperty("protected")]
		public bool Protected { get; set; }
	}
}
