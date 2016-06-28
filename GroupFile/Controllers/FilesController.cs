using System;
using System.IO;
using System.Web.Mvc;
using System.Collections.Generic;
using GroupFile.Models;
using System.Linq;

namespace GroupFile.Controllers
{
    public class FilesController : Controller
    {
        public static readonly string PATH_ROOT_UPLOADED = System.Web.HttpContext.Current.Server.MapPath("~/rootuploaded");
        public static readonly char[] DELIMITER_CHARS = { '_', '-', ' ' };

        // GET: Files
        public ActionResult Index()
        {
            List<SplitFileModel> listFile = ProcessDirectory(PATH_ROOT_UPLOADED);
            return View(listFile);
        }

        public List<SplitFileModel> ProcessDirectory(string pathfile)
        {
            List<SplitFileModel> listFile = new List<SplitFileModel>();

            foreach (string directory in Directory.GetDirectories(pathfile))
            {
                listFile.AddRange(ProcessDirectory(directory));
            }

            try
            {
                foreach (string file in Directory.GetFiles(pathfile))
                {
                    listFile.Add(SplitFileName(Path.GetFileNameWithoutExtension(file)));
                }
            }
            catch (DirectoryNotFoundException e)
            {

            }

            return listFile;
        }

        public SplitFileModel SplitFileName(string filename)
        {
            SplitFileModel splitFile = new SplitFileModel();

            if (ContainsDelimiter(filename))
            {
                foreach (char delimiter in DELIMITER_CHARS)
                {
                    string[] words = filename.Split(delimiter);
                    if (words.Length > 1)
                    {
                        if (ContainsDelimiter(words[words.Length - 1]))
                        {
                            continue;
                        }
                        else
                        {
                            splitFile.link = delimiter.ToString();
                            splitFile.suffix = words[words.Length - 1];
                            splitFile.prefix = String.Join(delimiter.ToString(), words.Take(words.Length - 1));
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                splitFile.prefix = filename;
            }

            return splitFile;
        }

        public bool ContainsDelimiter(string text)
        {
            return text.IndexOfAny(DELIMITER_CHARS) != -1;
        }
    }
}