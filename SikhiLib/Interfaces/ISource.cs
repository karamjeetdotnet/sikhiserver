using Newtonsoft.Json;
using SikhiLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SikhiLib.Interfaces
{
    public interface ISource: ILocale
    {
        [JsonProperty("length")]
        int? Length { get; set; }

        [JsonProperty("page_name_english")]
        string EnglishPageName { get; set; }

        [JsonProperty("page_name_gurmukhi")]
        string GurmukhiPageName { get; set; }

        [JsonProperty("sections")]
        List<Section> Sections { get; set; }
    }
}
