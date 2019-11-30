using System;
using System.Collections.Generic;

namespace SikhiDB.Models
{
    public partial class languages
    {
        public long id { get; set; }
        public long locale_id { get; set; }
        public long? file_source_id { get; set; }

        public virtual file_source file_source_ { get; set; }
        public virtual locale locale_ { get; set; }
    }
}
