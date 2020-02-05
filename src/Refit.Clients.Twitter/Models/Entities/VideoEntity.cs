namespace Refit.Clients.Twitter.Models.Entities
{
	using Newtonsoft.Json;

	public class VideoEntity
	{
		public int[] AspectRatio { get; set; }
		[JsonProperty("duration_millis")]
		public int DurationMilliseconds { get; set; }
		public VideoVariantEntity[] Variants { get; set; }
	}
}