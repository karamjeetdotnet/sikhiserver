using System;
using System.Collections.Generic;

namespace SikhiDB.Models
{
    public partial class db_system_info
    {
        public long id { get; set; }
        public DateTime datetime { get; set; }
        public string information { get; set; }
    }
}
