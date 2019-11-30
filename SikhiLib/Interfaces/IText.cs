using Newtonsoft.Json;
using SikhiLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SikhiLib.Interfaces
{
    public interface IText
    {
        [JsonProperty("id")]
        string GurbaniDbId { get; set; }

        [JsonProperty("sttm_id")]
        long? SttmId { get; set; }

        [JsonProperty("writer")]
        string Writer { get; set; }

        [JsonProperty("section")]
        string Section { get; set; }

        [JsonProperty("subsection")]
        string SubSection { get; set; }

        [JsonProperty("lines")]
        List<TextLine> Lines { get; set; }
    }
}
