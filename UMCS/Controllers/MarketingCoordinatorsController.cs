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
        public ActionResult SendEmail(string s_email, string cc, string subject, string body)
        {
            //var student = db.Students.SingleOrDefault(s => s.ID == student_id);

            var fromEmail = new MailAddress("umcsystem@gmail.com");
            var toEmail = new MailAddress(s_email);
            var fromEmailPassword = "Comp1640";

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
                IsBodyHtml = true,
            })
                smtp.Send(message);
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
