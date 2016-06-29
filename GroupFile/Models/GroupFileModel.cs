using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GroupFile.Models
{
    public class GroupFileModel
    {
        public List<FileModel> Files { get; set; }
        public int Group { get; set; }

        public GroupFileModel()
        {
            this.Files = new List<FileModel>();
        }
    }

    public class FileModel
    {
        public string FullPath { get; set; }
        public SplitFileModel SpliFileName { get; set; }
    }

    public class SplitFileModel
    {
        public string prefix { get; set; }
        public int link { get; set; }
        public string suffix { get; set; }
        public int isGroupDigit { get; set; }
    }
}