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

        // GET: Faculty1
        public ActionResult ShowReport(string year)
        {
            //int intYear = Convert.ToInt32(year);
            //var faculties = db.Faculties1;
            //var contribution = db.Contributions.Where(c => c.DateSubmit.Value.Year ==intYear);
            List<ReportModel> report = new List<ReportModel>();

            //foreach (var facultiesItem in faculties)
            //{
            //    var Count = 0;
            //    foreach (var contributionItem in contribution.Where(c => c.Student.FacultiesID == facultiesItem.CategoryId))
            //    {
            //        Count++;
            //    }
            //    report.Add(new DataPoint()
            //    {
            //        CategoryId = facultiesItem.CategoryId,
            //        CategoryName = facultiesItem.CategoryName,
            //        NumberOfIssue = Count,
            //    });
            //}
            //ViewBag.MonthReport = month;
            //ViewBag.YearReport = year;
            //GetCateMenu();
            return View(report);
        }
    }
}
