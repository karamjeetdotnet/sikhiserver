using System;
using System.Collections.Generic;

namespace SikhiDB.Models
{
    public partial class locale
    {
        public locale()
        {
            bani_index = new HashSet<bani_index>();
            languages = new HashSet<languages>();
            source_index = new HashSet<source_index>();
            source_index_range = new HashSet<source_index_range>();
            translation_source = new HashSet<translation_source>();
            writer = new HashSet<writer>();
        }

        public long id { get; set; }
        public string gurmukhi { get; set; }
        public string english { get; set; }
        public string internatinal { get; set; }

        public virtual ICollection<bani_index> bani_index { get; set; }
        public virtual ICollection<languages> languages { get; set; }
        public virtual ICollection<source_index> source_index { get; set; }
        public virtual ICollection<source_index_range> source_index_range { get; set; }
        public virtual ICollection<translation_source> translation_source { get; set; }
        public virtual ICollection<writer> writer { get; set; }
    }
}
