using System;
using System.IO;
using System.Web.Mvc;
using System.Collections.Generic;

namespace GroupFile.Controllers
{
    public class FilesController : Controller
    {
        public static readonly string PATH_ROOT_UPLOADED = System.Web.HttpContext.Current.Server.MapPath("~/rootuploaded");

        // GET: Files
        public ActionResult Index()
        {
            List<string> listFile = ProcessDirectory(PATH_ROOT_UPLOADED);
            return View(listFile);
        }

        public List<string> ProcessDirectory(string pathfile)
        {
            List<string> listFile = new List<string>();

            foreach (string directory in Directory.GetDirectories(pathfile))
            {
                listFile.AddRange(ProcessDirectory(directory));
            }
            
            try
            {
                foreach (string file in Directory.GetFiles(pathfile))
                {
                    listFile.Add(Path.GetFullPath(file));
                }
            }
            catch (DirectoryNotFoundException e)
            {

            }

            return listFile;
        }
    }
}