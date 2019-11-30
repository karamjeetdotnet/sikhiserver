using System;
using System.Collections.Generic;

namespace SikhiDB.Models
{
    public partial class source_index_range
    {
        public source_index_range()
        {
            Inversesource_index_range_ = new HashSet<source_index_range>();
            bani_textsection_source_ = new HashSet<bani_text>();
            bani_textsubsection_source_ = new HashSet<bani_text>();
        }

        public long id { get; set; }
        public long source_index_id { get; set; }
        public long? start_page { get; set; }
        public long? end_page { get; set; }
        public long locale_id { get; set; }
        public string description { get; set; }
        public long? source_index_range_id { get; set; }
        public long? file_source_id { get; set; }

        public bool is_subsection { get; set; }

        public virtual file_source file_source_ { get; set; }
        public virtual locale locale_ { get; set; }
        public virtual source_index source_index_ { get; set; }
        public virtual source_index_range source_index_range_ { get; set; }
        public virtual ICollection<source_index_range> Inversesource_index_range_ { get; set; }
        public virtual ICollection<bani_text> bani_textsection_source_ { get; set; }
        public virtual ICollection<bani_text> bani_textsubsection_source_ { get; set; }
    }
}
