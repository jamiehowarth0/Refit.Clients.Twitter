using Newtonsoft.Json;

namespace Refit.Clients.Twitter.Models.Entities
{
    public class MediaSizesEntity
	{
		[JsonProperty("w")]
		public int Width { get; set; }

		[JsonProperty("h")]
		public int Height { get; set; }

		[JsonProperty("resize")]
		public string ResizeMode { get; set; }
	}
}
