using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Refit.Clients.Twitter.Models
{
	public class MediaInit
	{
		[JsonProperty("media_id")]
		public long ID { get; set; }
		[JsonProperty("media_id_string")]
		public string IDAsString { get; set; }
		public int Size { get; set; }
		[JsonProperty("expires_after_secs")]
		public int ExpiresAfterSecs { get; set; }
		public MediaInitImage Image { get; set; }
	}

	public class MediaInitImage
	{
		[JsonProperty("image_type")]
		public string ImageType { get; set; }
		[JsonProperty("w")]
		public int Width { get; set; }
		[JsonProperty("h")]
		public int Height { get; set; }
	}

}
