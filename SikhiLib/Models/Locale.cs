﻿using SikhiLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SikhiLib.Models
{
    public class Locale : ILocale
    {
        public string GurmukhiName { get; set; }
        public string EnglishName { get; set; }
        public string InternationalName { get; set; }
    }
}
