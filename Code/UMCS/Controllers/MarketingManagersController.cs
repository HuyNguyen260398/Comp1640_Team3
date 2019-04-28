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

        public ActionResult ContributionsList(string id, int? page)
        {
            int f_id = Convert.ToInt32(id);
            var contributesList = db.Contributions.Where(c => c.Student.FacultiesID == f_id);
            var selectedContributes = contributesList.Where(s => s.Status == "Selected" || s.Status == "Commented").OrderBy(s => s.DateSubmit).ToPagedList(page ?? 1, 10);
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

            return View(faculties.OrderBy(f => f.FacultyName).ToPagedList(page ?? 1 , 8));
        }

        public ActionResult Teachers(int? page, string t_name, string role, string faculty, string gender)
        {
            List<SelectListItem> list1 = new List<SelectListItem>();
            list1.Add(new SelectListItem { Text = "Gender", Value = "refresh" });
            list1.Add(new SelectListItem { Text = "Male", Value = "Male" });
            list1.Add(new SelectListItem { Text = "Female", Value = "Female" });

            List<SelectListItem> list2 = new List<SelectListItem>();
            list2.Add(new SelectListItem { Text = "Role", Value = "refresh" });
            list2.Add(new SelectListItem { Text = "Teacher", Value = "Faculty" });
            list2.Add(new SelectListItem { Text = "Marketing Coordinator", Value = "Marketing Coordinator" });

            List<SelectListItem> list3 = new List<SelectListItem>();
            list3.Add(new SelectListItem { Text = "Faculty", Value = "refresh" });
            foreach (var item in db.Faculties)
            {
                list3.Add(new SelectListItem()
                {
                    Text = item.FacultyName.ToString(),
                    Value = item.FacultyName.ToString()
                });
            }

            ViewBag.Gender = list1;
            ViewBag.Role = list2;
            ViewBag.Faculty = list3;

            var teachers = db.Faculties1.AsQueryable();

            if (!String.IsNullOrEmpty(t_name))
            {
                teachers = teachers.Where(t => t.FirstName.Contains(t_name) || t.LastName.Contains(t_name));
            }

            if (role != null && role != "refresh")
            {
                teachers = teachers.Where(t => t.Role == role);
            }

            if (faculty != null && faculty != "refresh")
            {
                teachers = teachers.Where(t => t.Faculty.FacultyName.Equals(faculty));
            }

            if (gender != null && gender != "refresh")
            {
                teachers = teachers.Where(t => t.Gender.Equals(gender));
            }

            return View(teachers.OrderBy(t => t.FirstName).ToPagedList(page ?? 1 , 8));
        }

        public ActionResult Students(int? page, string s_name, string gender, string faculty)
        {
            List<SelectListItem> list1 = new List<SelectListItem>();
            list1.Add(new SelectListItem { Text = "Gender", Value = "refresh" });
            list1.Add(new SelectListItem { Text = "Male", Value = "Male" });
            list1.Add(new SelectListItem { Text = "Female", Value = "Female" });

            List<SelectListItem> list2 = new List<SelectListItem>();
            list2.Add(new SelectListItem { Text = "Faculty", Value = "refresh" });
            foreach (var item in db.Faculties)
            {
                list2.Add(new SelectListItem()
                {
                    Text = item.FacultyName.ToString(),
                    Value = item.FacultyName.ToString()
                });
            }

            ViewBag.Gender = list1;
            ViewBag.Faculty = list2;

            var students = db.Students.AsQueryable();

            if (!String.IsNullOrEmpty(s_name))
            {
                students = students.Where(s => s.FirstName.Contains(s_name) || s.LastName.Contains(s_name));
            }

            if (faculty != null && faculty != "refresh")
            {
                students = students.Where(s => s.Faculty.FacultyName.Equals(faculty));
            }

            if (gender != null && gender != "refresh")
            {
                students = students.Where(s => s.Gender.Equals(gender));
            }

            return View(students.OrderBy(s => s.FirstName).ToPagedList(page ?? 1, 8));
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