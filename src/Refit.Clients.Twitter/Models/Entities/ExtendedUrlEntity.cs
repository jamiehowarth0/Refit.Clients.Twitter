using System;

namespace Refit.Clients.Twitter.Models.Entities
{
	public class ExtendedUrlEntity
	{
		public Uri Url { get; set; }
		public int Status { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
	}
}
