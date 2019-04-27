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
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SetClosureDate()
        {
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

            return View();
        }
    }
}