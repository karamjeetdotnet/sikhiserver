using System;
using System.Collections.Generic;

namespace SikhiDB.Models
{
    public partial class translation_source
    {
        public long id { get; set; }
        public long locale_id { get; set; }
        public long? source_index_id { get; set; }
        public string language { get; set; }
        public long? file_source_id { get; set; }

        public virtual file_source file_source_ { get; set; }
        public virtual locale locale_ { get; set; }
        public virtual source_index source_index_ { get; set; }
    }
}
