using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SikhiLib.Interfaces
{
    public interface ILocale
    {
        [JsonProperty("name_gurmukhi")]
        string GurmukhiName { get; set; }
        [JsonProperty("name_english")]
        string EnglishName { get; set; }
        [JsonProperty("name_international")]
        string InternationalName { get; set; }
    }
}
