using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UMCS.Models;

namespace UMCS.Controllers
{
    public class MarketingCoordinatorsController : Controller
    {
        private UMCSEntities db = new UMCSEntities();

        public ActionResult Accept()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(string email)
        {
            return View();
        }

        public ActionResult LoadData()
        {
            var files = db.Contributions.Where(f => f.Status == "Pending").ToList();
            return View(files);
        }


        public ActionResult Bt_Accept(string id)
        {
            int c_id = Convert.ToInt32(id);
            db.Contributions.Single(a => a.ID == c_id).Status = "Selected";
            db.SaveChanges();


            return RedirectToAction("LoadData");
        }


    }
}
