using Newtonsoft.Json;
using SikhiLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SikhiLib.Models
{
    public class Range : IRange
    {
        public string StartLine { get; set; }
        public string EndLine { get; set; }
    }
}
