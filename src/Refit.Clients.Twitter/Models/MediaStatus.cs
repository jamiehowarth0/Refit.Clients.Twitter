using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Refit.Clients.Twitter.Models
{

    public class MediaStatus
    {
        [JsonProperty("media_id")]
        public long ID { get; set; }
        [JsonProperty("media_id_string")]
        public string IDString { get; set; }
        [JsonProperty("expires_after_secs")]
        public int ExpiresAfterSecs { get; set; }
        public ProcessingInfoBase processing_info { get; set; }
    }

    public class ProcessingInfoBase
    {
        public string state { get; set; }
        public int progress_percent { get; set; }
    }

    public class ProcessingInProgress : ProcessingInfoBase
    {
        
    }

}
