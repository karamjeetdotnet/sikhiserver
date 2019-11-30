using Newtonsoft.Json;
using SikhiLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SikhiLib.Models
{
    public class Source : ISource
    {
        public int? Length { get; set; }
        public string EnglishPageName { get; set; }
        public string GurmukhiPageName { get; set; }
        public List<Section> Sections { get; set; }
        public string GurmukhiName { get; set; }
        public string EnglishName { get; set; }
        public string InternationalName { get; set; }
    }
}
