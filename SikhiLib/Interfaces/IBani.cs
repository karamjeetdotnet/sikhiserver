using Newtonsoft.Json;
using SikhiLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SikhiLib.Interfaces
{
    public interface IBani: ILocale
    {
        [JsonProperty("lines")]
        List<Range> Lines { get; set; }
    }
}
