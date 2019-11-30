using SikhiLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SikhiLib.Models
{
    public class TextLine : ITextLine
    {
        public string GurbaniDbId { get; set; }
        public long SourcePage { get; set; }
        public long? SourceLine { get; set; }
        public string Gurmukhi { get; set; }
        public string Pronunciation { get; set; }
        public string PronunciationInformation { get; set; }
        public string Type { get; set; }
        public string Translation { get; set; }
    }
}
