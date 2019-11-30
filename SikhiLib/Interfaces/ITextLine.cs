using Newtonsoft.Json;
using SikhiLib.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace SikhiLib.Interfaces
{
    public interface ITextLine
    {
        [JsonProperty("id")]
        string GurbaniDbId { get; set; }

        [JsonProperty("source_page")]
        long SourcePage { get; set; }

        [JsonProperty("source_line")]
        long? SourceLine { get; set; }

        [JsonProperty("gurmukhi")]
        string Gurmukhi { get; set; }

        [JsonProperty("pronunciation")]
        string Pronunciation { get; set; }

        [JsonProperty("pronunciation_information")]
        string PronunciationInformation { get; set; }

        [JsonProperty("type")]
        string Type { get; set; }

        [JsonProperty("translations")]
        [JsonConverter(typeof(TranslationConverter))]
        string Translation { get; set; }
    }
}
