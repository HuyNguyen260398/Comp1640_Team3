using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using UMCS.Models;

namespace UMCS.Controllers
{
    public class MarketingCoordinatorsController : Controller
    {
        private UMCSEntities db = new UMCSEntities();

        [HttpGet]
        public ActionResult LoginEmail(int id)
        {
            ViewBag.ContributionId = id;
            Faculty1 faculty = db.Faculties1.Find(Convert.ToInt32(Session["MC_ID"]));
            return PartialView("../MarketingCoordinators/_LoginEmail", faculty);
        }

        [HttpGet]
        public ActionResult SendEmail(int id)
        {
            Contribution contribution = db.Contributions.Find(id);
            return View(contribution);
        }

        [HttpPost]
        public ActionResult SendEmail(Contribution contribution, string s_email, string subject, string body)
        {
            var faculty  = db.Faculties1.Find(Convert.ToInt32(Session["MC_ID"]));

            //var fromEmail = new MailAddress(faculty.Email);
            var fromEmail = new MailAddress(faculty.Email);
            var toEmail = new MailAddress(s_email);
            var fromEmailPassword = faculty.EmailPW;
            //var fromEmailPassword = faculty.EmailPW;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
            })
                try
                {
                    smtp.Send(message);
                    contribution.Status = "Commented";
                    db.Entry(contribution).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            return RedirectToAction("LoadData");
        }

        public ActionResult LoadData()
        {
            var files = db.Contributions.ToList();
            return View(files);
        }

        public ActionResult ChageStatus(int id)
        {
            Session["ChangeStatus"] = id;
            return RedirectToAction("LoadData");
        }

        public ActionResult UpdateStatus(int id, string status)
        {
            Contribution contribution = db.Contributions.FirstOrDefault(m => m.ID == id);
            if (contribution != null)
            {
                Session["ChangeStatus"] = null;
                contribution.Status = status;
                db.Entry(contribution).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("LoadData");
        }

        //public ActionResult Bt_Accept(string id)
        //{
        //    int c_id = Convert.ToInt32(id);
        //    db.Contributions.Single(a => a.ID == c_id).Status = "Selected";
        //    db.SaveChanges();


        //    return RedirectToAction("LoadData");
        //}

        // GET: MarketingCoordinators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty1 faculty1 = db.Faculties1.Find(id);
            if (faculty1 == null)
            {
                return HttpNotFound();
            }
            return View(faculty1);
        }

        // GET: MarketingCoordinators/Create
        public ActionResult Create()
        {
            ViewBag.FacultiesID = new SelectList(db.Faculties, "ID", "FacultyName");
            ViewBag.MarketingManagerID = new SelectList(db.MarketingManagers, "ID", "FirstName");
            return View();
        }

        // POST: MarketingCoordinators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MarketingManagerID,FacultiesID,Role,FirstName,LastName,Gender,Age,Image,Phone,Email,Address,Username,Password")] Faculty1 faculty1)
        {
            if (ModelState.IsValid)
            {
                db.Faculties1.Add(faculty1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacultiesID = new SelectList(db.Faculties, "ID", "FacultyName", faculty1.FacultiesID);
            ViewBag.MarketingManagerID = new SelectList(db.MarketingManagers, "ID", "FirstName", faculty1.MarketingManagerID);
            return View(faculty1);
        }

        // GET: MarketingCoordinators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty1 faculty1 = db.Faculties1.Find(id);
            if (faculty1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultiesID = new SelectList(db.Faculties, "ID", "FacultyName", faculty1.FacultiesID);
            ViewBag.MarketingManagerID = new SelectList(db.MarketingManagers, "ID", "FirstName", faculty1.MarketingManagerID);
            return View(faculty1);
        }

        // POST: MarketingCoordinators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MarketingManagerID,FacultiesID,Role,FirstName,LastName,Gender,Age,Image,Phone,Email,Address,Username,Password")] Faculty1 faculty1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculty1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacultiesID = new SelectList(db.Faculties, "ID", "FacultyName", faculty1.FacultiesID);
            ViewBag.MarketingManagerID = new SelectList(db.MarketingManagers, "ID", "FirstName", faculty1.MarketingManagerID);
            return View(faculty1);
        }

        // GET: MarketingCoordinators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculty1 faculty1 = db.Faculties1.Find(id);
            if (faculty1 == null)
            {
                return HttpNotFound();
            }
            return View(faculty1);
        }

        // POST: MarketingCoordinators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculty1 faculty1 = db.Faculties1.Find(id);
            db.Faculties1.Remove(faculty1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
