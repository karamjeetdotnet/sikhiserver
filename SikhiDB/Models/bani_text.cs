using System;
using System.Collections.Generic;

namespace SikhiDB.Models
{
    public partial class bani_text
    {
        public bani_text()
        {
            bani_text_line = new HashSet<bani_text_line>();
        }

        public long id { get; set; }
        public string gurbani_db_id { get; set; }
        public long? sttm_id { get; set; }
        public long writer_id { get; set; }
        public long? section_source_id { get; set; }
        public long? subsection_source_id { get; set; }
        public long? file_source_id { get; set; }

        public virtual file_source file_source_ { get; set; }
        public virtual source_index_range section_source_ { get; set; }
        public virtual source_index_range subsection_source_ { get; set; }
        public virtual writer writer_ { get; set; }
        public virtual ICollection<bani_text_line> bani_text_line { get; set; }
    }
}
