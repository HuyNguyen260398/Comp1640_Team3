using System;
using System.Collections;
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

        // GET: Show statistical analysis  
        public ActionResult ShowStatistic(string year)
        {
            int intYear = Convert.ToInt32(year);
            if (intYear == 0)
            {
                intYear = DateTime.Now.Year;
            }
            var faculties = db.Faculties;
            var contribution = db.Contributions.Where(c => c.DateSubmit.Value.Year == intYear);
            List<ReportModel> report = new List<ReportModel>();
            int total = contribution.Count();

            foreach (var facultiesItem in faculties)
            {
                var contributionCount = 0;
                ArrayList stList = new ArrayList();

                foreach (var contributionItem in contribution.Where(c => c.FID == facultiesItem.ID))
                {
                    contributionCount++;

                    int i;
                    for (i = 0; i < stList.Count && !stList[i].Equals(contributionItem.StudentID); i++) ;

                    if (i == stList.Count)
                    {
                        stList.Add(contributionItem.StudentID);
                    }
                }

                float percent = (float)contributionCount / (float)total;
                report.Add(new ReportModel()
                {
                    FacultyId = facultiesItem.ID,
                    FacultyName = facultiesItem.FacultyName,
                    NumberOfContribution = contributionCount,
                    PercentOfContribution = String.Format("{0:P1}", percent),
                    NumberOfContributor = stList.Count,
                });
            }
            
            ViewBag.YearReport = year;
            return View(report.ToList());
        }

        // GET: Show summarized report  
        public ActionResult ShowReport(string year)
        {
            Session["year"] = year;
            int intYear = Convert.ToInt32(year);
            if (intYear == 0)
            {
                intYear = DateTime.Now.Year;
            }
            var faculties = db.Faculties;
            var contribution = db.Contributions.Where(c => c.DateSubmit.Value.Year == intYear);
            List<ReportModel> report = new List<ReportModel>();
            int total = contribution.Count();

            foreach (var facultiesItem in faculties)
            {
                var contributionCount = 0;
                ArrayList stList = new ArrayList();

                foreach (var contributionItem in contribution.Where(c => c.FID == facultiesItem.ID))
                {
                    contributionCount++;

                    int i;
                    for (i = 0; i < stList.Count && !stList[i].Equals(contributionItem.StudentID); i++) ;

                    if (i == stList.Count)
                    {
                        stList.Add(contributionItem.StudentID);
                    }
                }

                float percent = (float)contributionCount / (float)total;
                report.Add(new ReportModel()
                {
                    FacultyId = facultiesItem.ID,
                    FacultyName = facultiesItem.FacultyName,
                    NumberOfContribution = contributionCount,
                    PercentOfContribution = String.Format("{0:P1}", percent),
                    NumberOfContributor = stList.Count,
                });
            }

            ViewBag.TotalContribution = report.Sum(e => e.NumberOfContribution);
            ViewBag.TotalContributor = report.Sum(e => e.NumberOfContributor);
            ViewBag.YearReport = year;
            return View(report);
        }
    }
}
