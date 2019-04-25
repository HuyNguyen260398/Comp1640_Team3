using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMCS.Models;
using UMCS.Models.Extended;

namespace UMCS.Controllers
{
    public class MarketingManagersController : Controller
    {
        UMCSEntities db = new UMCSEntities();

        // GET: MarketingManagers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FacultiesList()
        {
            var falcultieslist = db.Faculties.ToList();
            return View(falcultieslist);
        }

        public ActionResult ContributionsList(string id)
        {
            int f_id = Convert.ToInt32(id);
            var contributesList = db.Contributions.Where(c => c.Student.FacultiesID == f_id);
            var selectedContributes = contributesList.Where(s => s.Status == "Selected" || s.Status == "Commented").ToList();
            ViewBag.FID = f_id;
            return View(selectedContributes);
        }

        public FileResult DownloadZip(string id)
        {
            int f_id = Convert.ToInt32(id);
            var contributesList = db.Contributions.Where(c => c.Student.FacultiesID == f_id);
            var selectedContributes = contributesList.Where(s => s.Status == "Selected" || s.Status == "Commented").ToList();

            //List<string> filePaths = new List<string>();
            //foreach(var item in selectedContributes)
            //{
            //    filePaths.Add(item.ArchiveLink);
            //}
            
            List<FileModel> files = new List<FileModel>();
            foreach (var item in selectedContributes)
            {
                files.Add(new FileModel()
                {
                    FileName = item.Title,
                    FilePath = item.ArchiveLink
                });
            }

            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("Files");
                foreach (FileModel file in files)
                {
                    zip.AddFile(file.FilePath, "Files");
                }
                string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    zip.Save(memoryStream);
                    return File(memoryStream.ToArray(), "application/zip", zipName);
                }
            }
        }
    }
}