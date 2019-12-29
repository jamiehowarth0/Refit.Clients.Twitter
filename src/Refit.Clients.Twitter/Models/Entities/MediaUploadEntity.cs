using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Refit.Clients.Twitter.Models.Entities
{
    public class MediaUploadEntity
    {
        [JsonProperty("media_id")]
        public ulong MediaID { get; set; }
        [JsonProperty("media_id_string")]
        public string MediaIDString { get; set; }
        public int Size { get; set; }
        public int ExpiresAfterSecs { get; set; }

        public MediaUploadEntityImage Image { get; set; }
    }

    public class MediaUploadEntityImage
    {
        public string ImageType { get; set; }
        [JsonProperty("w")]
        public int Width { get; set; }
        [JsonProperty("h")]
        public int Height { get; set; }
    }
}
