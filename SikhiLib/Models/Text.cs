using SikhiLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SikhiLib.Models
{
    public class Text : IText
    {
        public string GurbaniDbId { get; set; }
        public long? SttmId { get; set; }
        public string Writer { get; set; }
        public string Section { get; set; }
        public string SubSection { get; set; }
        public List<TextLine> Lines { get; set; }
    }
}
