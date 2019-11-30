using Newtonsoft.Json;
using SikhiLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SikhiLib.Interfaces
{
    public interface ISection: ILocale
    {
        [JsonProperty("description")]
        string Description { get; set; }

        [JsonProperty("start_page")]
        long? StartPage { get; set; }

        [JsonProperty("end_page")]
        long? EndPage { get; set; }

        [JsonProperty("subsections")]
        List<Section> SubSections { get; set; }
    }
}
