using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SikhiLib.Interfaces
{
    public interface ITranslationSource: ILocale
    {
        [JsonProperty("source")]
        string Source { get; set; }

        [JsonProperty("language")]
        string Language { get; set; }
    }
}
