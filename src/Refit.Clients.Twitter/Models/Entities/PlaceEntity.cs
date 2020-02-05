namespace Refit.Clients.Twitter.Models.Entities
{
	public class PlaceEntity
	{
		public string Name { get; set; }

		public string CountryCode { get; set; }

		public string Country { get; set; }

		public AttributesEntity Attributes { get; set; }

		public string Url { get; set; }

		public string ID { get; set; }

		public BoundingBoxEntity BoundingBox { get; set; }

		public string FullName { get; set; }

		public string PlaceType { get; set; }
	}
}
