using System;
using System.IO;
using System.Web.Mvc;
using System.Collections.Generic;
using GroupFile.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace GroupFile.Controllers
{
    public class FilesController : Controller
    {
        public static string PATH_ROOT_UPLOADED = System.Web.HttpContext.Current.Server.MapPath("~/rootuploaded");
        public static char[] DELIMITER_CHARS = { ' ', '-', '_' };
        private int indexGroup = 1;
        private GroupFileModel cannotGroup = new GroupFileModel();

        public ActionResult Index()
        {
            List<GroupFileModel> groupFiles = ProcessDirectory(PATH_ROOT_UPLOADED);
            cannotGroup.Group = indexGroup++;
            groupFiles.Add(cannotGroup);
            return View(groupFiles);
        }

        public List<GroupFileModel> ProcessDirectory(string pathfile)
        {
            List<GroupFileModel> group = new List<GroupFileModel>();
            try
            {
                foreach (string directory in Directory.GetDirectories(pathfile))
                {
                    group.AddRange(ProcessDirectory(directory));
                }

                List<FileModel> listFiles = new List<FileModel>();
                foreach (string file in Directory.GetFiles(pathfile))
                {
                    FileModel listFile = new FileModel();
                    listFile.FullPath = Path.GetFullPath(file);
                    listFile.SpliFileName = SplitFileName(Path.GetFileNameWithoutExtension(file));
                    listFiles.Add(listFile);
                }
                group.AddRange(GroupFile(listFiles));
            }
            catch (DirectoryNotFoundException e)
            {

            }

            return group;
        }

        public List<GroupFileModel> GroupFile(List<FileModel> listFiles)
        {
            List<GroupFileModel> group = new List<GroupFileModel>();

            var groupFiles = listFiles.OrderByDescending(d => d.SpliFileName.isGroupDigit).ThenBy(l => l.SpliFileName.link).ThenBy(p => p.SpliFileName.prefix)
                .GroupBy(g => new { g.SpliFileName.isGroupDigit, g.SpliFileName.link, g.SpliFileName.prefix })
                .ToList();

            foreach (var groupFile in groupFiles)
            {
                if (groupFile.Count() > 1)
                {
                    GroupFileModel groupFileModel = new GroupFileModel();
                    List<FileModel> Files = new List<FileModel>();

                    foreach (FileModel file in groupFile)
                    {
                        Files.Add(file);
                    }
                    groupFileModel.Files = Files;
                    groupFileModel.Group = indexGroup++;
                    group.Add(groupFileModel);
                }
                else
                {
                    foreach (FileModel file in groupFile)
                    {
                        cannotGroup.Files.Add(file);
                    }
                }
            }

            return group;
        }

        public SplitFileModel SplitFileName(string filename)
        {
            SplitFileModel splitFile = new SplitFileModel();

            int index = NumberInLastString(filename);
            if (index == -1)
            {
                splitFile.prefix = filename;
                splitFile.isGroupDigit = 0;
                splitFile.link = -1;

                if (filename.IndexOfAny(DELIMITER_CHARS) != -1)
                {
                    for (int i = 0; i < DELIMITER_CHARS.Length; i++)
                    {
                        string[] words = filename.Split(DELIMITER_CHARS[i]);
                        if (words.Length > 1)
                        {
                            if (words[words.Length - 1].Length <= 1)
                            {
                                splitFile.link = i;
                                splitFile.suffix = words[words.Length - 1];
                                splitFile.prefix = String.Join(DELIMITER_CHARS[i].ToString(), words.Take(words.Length - 1));
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                splitFile.suffix = filename.Substring(index);
                splitFile.isGroupDigit = 1;
                if (DELIMITER_CHARS.Contains(filename[index - 1]))
                {
                    splitFile.link = Array.IndexOf(DELIMITER_CHARS, filename[index - 1]);
                    splitFile.prefix = filename.Substring(0, index - 1);
                }
                else
                {
                    splitFile.link = -1;
                    splitFile.prefix = filename.Substring(0, index);
                }
            }

            return splitFile;
        }

        public int NumberInLastString(string text)
        {
            int index = -1;
            for (int i = text.Length - 1; i >= 0; i--)
            {
                if (Char.IsDigit(text[i]))
                {
                    index = i;
                }
                else
                {
                    break;
                }
            }
            return index;
        }

    }
}