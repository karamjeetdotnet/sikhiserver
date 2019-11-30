using System;
using System.Collections.Generic;

namespace SikhiDB.Models
{
    public partial class bani_index_range
    {
        public long id { get; set; }
        public long bani_index_id { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public long? file_source_id { get; set; }

        public virtual bani_index bani_index_ { get; set; }
        public virtual file_source file_source_ { get; set; }
    }
}
