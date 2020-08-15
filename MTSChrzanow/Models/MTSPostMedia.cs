﻿using Newtonsoft.Json;

namespace MTSChrzanow.Models
{
	public class MTSPostMedia
	{
		[JsonProperty("guid")]
		public Guid Guid { get; set; }
	}

	public class Guid
	{
		[JsonProperty("rendered")]
		public string Rendered { get; set; }
	}
}
