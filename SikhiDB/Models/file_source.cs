using System;
using System.Collections.Generic;

namespace SikhiDB.Models
{
    public partial class file_source
    {
        public file_source()
        {
            bani_index = new HashSet<bani_index>();
            bani_index_range = new HashSet<bani_index_range>();
            bani_text = new HashSet<bani_text>();
            bani_text_line = new HashSet<bani_text_line>();
            languages = new HashSet<languages>();
            source_index = new HashSet<source_index>();
            source_index_range = new HashSet<source_index_range>();
            translation_source = new HashSet<translation_source>();
            writer = new HashSet<writer>();
        }

        public long id { get; set; }
        public string file_name { get; set; }
        public string source { get; set; }
        public string content { get; set; }

        public virtual ICollection<bani_index> bani_index { get; set; }
        public virtual ICollection<bani_index_range> bani_index_range { get; set; }
        public virtual ICollection<bani_text> bani_text { get; set; }
        public virtual ICollection<bani_text_line> bani_text_line { get; set; }
        public virtual ICollection<languages> languages { get; set; }
        public virtual ICollection<source_index> source_index { get; set; }
        public virtual ICollection<source_index_range> source_index_range { get; set; }
        public virtual ICollection<translation_source> translation_source { get; set; }
        public virtual ICollection<writer> writer { get; set; }
    }
}
