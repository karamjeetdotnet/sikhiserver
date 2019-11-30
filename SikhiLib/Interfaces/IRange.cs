using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SikhiLib.Interfaces
{
    public interface IRange
    {
        [JsonProperty("start_line")]
        string StartLine { get; set; }
        [JsonProperty("end_line")]
        string EndLine { get; set; }
    }
}
