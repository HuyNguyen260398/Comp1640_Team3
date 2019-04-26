using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMCS.Models;
using UMCS.Models.Extended;
using PagedList;

namespace UMCS.Controllers
{
    public class MarketingManagersController : Controller
    {
        UMCSEntities db = new UMCSEntities();

        // GET: MarketingManagers
        public ActionResult Index()
        {
            ViewBag.Faculties = db.Faculties.Count();
            ViewBag.Teachers = db.Faculties1.Count();
            ViewBag.Students = db.Students.Count();
            ViewBag.Contributions = db.Contributions.Where(c => c.Status == "Selected" || c.Status == "Commented").Count();
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

        public ActionResult Faculties(int? page, string f_name)
        {
            var faculties = db.Faculties.AsQueryable();

            if (!String.IsNullOrEmpty(f_name))
            {
                faculties = faculties.Where(f => f.FacultyName.Contains(f_name));
            }

            return View(faculties.OrderBy(f => f.FacultyName).ToPagedList(page ?? 1 , 20));
        }

        public ActionResult Teachers()
        {
            var teachers = db.Faculties1.ToList();
            return View(teachers);
        }

        public ActionResult Students()
        {
            var students = db.Students.ToList();
            return View(students);
        }

        public FileResult DownloadZip(string id)
        {
            int f_id = Convert.ToInt32(id);
            var contributesList = db.Contributions.Where(c => c.Student.FacultiesID == f_id);
            var selectedContributes = contributesList.Where(s => s.Status == "Selected" || s.Status == "Commented").ToList();
            
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