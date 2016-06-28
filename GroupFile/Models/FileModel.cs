using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupFile.Models
{
    public class FileModel
    {
        public string FullPath { get; set; }
        public SplitFileModel SpliFileName { get; set; }
        public int Group { get; set; }
    }
}