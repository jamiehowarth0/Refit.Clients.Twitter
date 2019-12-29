namespace Refit.Clients.Twitter.Models.Entities
{
    public class EntitiesContainer
    {
        public UrlEntity[] Urls { get; set; }
        public HashTagEntity[] Hashtags { get; set; }
        public UserMentions[] UserMentions { get; set; }
        public SymbolEntity[] Symbols { get; set; }
        public MediaEntity[] Media { get; set; }
    }
}
