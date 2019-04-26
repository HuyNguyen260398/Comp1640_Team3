using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UMCS.Models;
using UMCS.Models.Extended;

namespace UMCS.Controllers
{
    public class Faculty1Controller : Controller
    {
        private UMCSEntities db = new UMCSEntities();

        public ActionResult Index()
        {
            return View(db.Faculties1.ToList());
        }

        // GET: Faculty1
        public ActionResult ShowStatistic(string year)
        {
            int intYear = Convert.ToInt32(year);
            var faculties = db.Faculties;
            var contribution = db.Contributions.Where(c => c.DateSubmit.Value.Year == intYear);
            List<ReportModel> report = new List<ReportModel>();
            int total = contribution.Count();

            foreach (var facultiesItem in faculties)
            {
                var Count = 0;

                foreach (var contributionItem in contribution.Where(c => c.FID == facultiesItem.ID))
                {
                    Count++;
                }
                report.Add(new ReportModel()
                {
                    FacultyId = facultiesItem.ID,
                    FacultyName = facultiesItem.FacultyName,
                    NumberOfContribution = Count,
                    PercentOfContribution = "",
                    NumberOfContributor = 0,
                });
            }
            
            ViewBag.YearReport = year;
            return View(report.ToList());
        }
    }
}
