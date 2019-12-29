namespace Refit.Clients.Twitter.Models.Entities
{
    public class TrendLocationEntity
    {
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public int ParentID { get; set; }
        public PlacetypeEntity PlaceType { get; set; }
        public string Url { get; set; }
        public int woeid { get; set; }
    }
}