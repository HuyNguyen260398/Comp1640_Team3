using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UMCS.Models;

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
            return View(selectedContributes);
        }
    }
}