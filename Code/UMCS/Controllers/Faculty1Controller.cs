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
    public class Faculty1Controller : Controller
    {
        private UMCSEntities db = new UMCSEntities();

        // GET: MarketingCoordinators
        public ActionResult Index()
        {
            var faculties1 = db.Faculties1.Include(f => f.Faculty).Include(f => f.MarketingManager);
            return View(faculties1.ToList());
        }

        // GET: Faculty1/Details/5
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

        // GET: Faculty1/Create
        public ActionResult Create()
        {
            ViewBag.FacultiesID = new SelectList(db.Faculties, "ID", "FacultyName");
            ViewBag.MarketingManagerID = new SelectList(db.MarketingManagers, "ID", "FirstName");
            return View();
        }

        // POST: Faculty1/Create
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

        // GET: Faculty1/Edit/5
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

        // POST: Faculty1/Edit/5
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

        // GET: Faculty1/Delete/5
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

        // POST: Faculty1/Delete/5
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
