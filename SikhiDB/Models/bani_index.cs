using System;
using System.Collections.Generic;

namespace SikhiDB.Models
{
    public partial class bani_index
    {
        public bani_index()
        {
            bani_index_range = new HashSet<bani_index_range>();
        }

        public long id { get; set; }
        public long locale_id { get; set; }
        public long? file_source_id { get; set; }

        public virtual file_source file_source_ { get; set; }
        public virtual locale locale_ { get; set; }
        public virtual ICollection<bani_index_range> bani_index_range { get; set; }
    }
}
