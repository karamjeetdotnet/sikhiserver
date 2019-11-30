using System;
using System.Collections.Generic;

namespace SikhiDB.Models
{
    public partial class source_index
    {
        public source_index()
        {
            source_index_range = new HashSet<source_index_range>();
            translation_source = new HashSet<translation_source>();
        }

        public long id { get; set; }
        public long locale_id { get; set; }
        public int? length { get; set; }
        public string english_page_name { get; set; }
        public string gurmukhi_page_name { get; set; }
        public long? file_source_id { get; set; }

        public virtual file_source file_source_ { get; set; }
        public virtual locale locale_ { get; set; }
        public virtual ICollection<source_index_range> source_index_range { get; set; }
        public virtual ICollection<translation_source> translation_source { get; set; }
    }
}
