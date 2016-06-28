using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupFile.Models
{
    public class FileModel
    {
        public string FullPath { get; set; }
        public string FileNameWithoutExtension { get; set; }
        public SplitFileModel SpliFileName { get; set; }
        public int Group { get; set; }
    }

    public class SplitFileModel
    {
        public string prefix { get; set; }
        public string link { get; set; }
        public string suffix { get; set; }
    }
}