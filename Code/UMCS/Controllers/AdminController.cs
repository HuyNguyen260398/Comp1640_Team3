using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMCS.Models;

namespace UMCS.Controllers
{
    public class AdminController : Controller
    {
        UMCSEntities db = new UMCSEntities();

        [HttpGet]
        public ActionResult SetClosureDate()
        {
            var maxDate = db.ClosureDates.Max(d => d.AcademicYear);
            var currentYear = DateTime.Now.Year;

            if (currentYear > maxDate)
            {
                ViewBag.AcademicYear = currentYear.ToString();
            } else
            {
                ViewBag.AcademicYear = "Current Academic Year has been already set";
            }

            return View();
        }

        [HttpPost]
        public ActionResult SetClosureDate(ClosureDate cd)
        {
            if (cd.AcademicYear != null && cd.ClosureDate1 != null && cd.FinalClosureDate != null)
            {
                db.ClosureDates.Add(cd);
                db.SaveChanges();

                ViewBag.Message = "Success!";
            }
            else
            {
                ViewBag.Message = "Fail!";
            }

            return RedirectToAction("ViewClosureDate", "Admin"); ;
        }

        public ActionResult ViewClosureDate()
        {
            var closureDate = db.ClosureDates;
            return View(closureDate);
        }
    }
}