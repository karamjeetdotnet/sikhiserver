using SikhiLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SikhiLib.Models
{
    public class Section : ISection
    {
        public string Description { get; set; }
        public List<Section> SubSections { get; set; }
        public string GurmukhiName { get; set; }
        public string EnglishName { get; set; }
        public string InternationalName { get; set; }
        public long? StartPage { get; set; }
        public long? EndPage { get; set; }
    }
}
