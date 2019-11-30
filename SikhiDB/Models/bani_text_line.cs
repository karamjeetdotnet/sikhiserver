using System;
using System.Collections.Generic;

namespace SikhiDB.Models
{
    public partial class bani_text_line
    {
        public long id { get; set; }
        public string gurbani_db_id { get; set; }
        public long? bani_text_id { get; set; }
        public long? source_page { get; set; }
        public long? source_line { get; set; }
        public string gurmukhi { get; set; }
        public string pronunciation { get; set; }
        public string pronunciation_information { get; set; }
        public string translation { get; set; }
        public long? file_source_id { get; set; }

        public virtual bani_text bani_text_ { get; set; }
        public virtual file_source file_source_ { get; set; }
    }
}
