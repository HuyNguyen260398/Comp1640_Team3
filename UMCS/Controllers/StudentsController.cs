using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using UMCS.Models;

namespace UMCS.Controllers
{
    public class StudentsController : Controller
    {
        private UMCSEntities db = new UMCSEntities();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Student student, MarketingManager MM, MarketingCoordinator MC)
        {
            var model = db.Students.SingleOrDefault(s => s.Username == student.Username);
            var modelMM = db.MarketingManagers.SingleOrDefault(mm => mm.Username == MM.Username);
            var modelMC = db.MarketingCoordinators.SingleOrDefault(mc => mc.Username == MC.Username);

            if (model != null)
            {
                if (model.Password == student.Password)
                {
                    Session["S_ID"] = model.ID;
                    Session["Username"] = model.Username;
                    Session["Img"] = model.Image.ToString();
                    Session["MM_ID"] = null;
                    Session["MC_ID"] = null;
                    return RedirectToAction("Repository/"+Session["S_ID"], "Students");
                }
                else
                {
                    ViewBag.Error = "Invalid Username or Password!";
                    return View();
                }
            }
            else if (modelMM !=null)
            {
                if (modelMM.Password == MM.Password)
                {
                    Session["MM_ID"] = modelMM.ID;
                    Session["S_ID"] = null;
                    Session["MC_ID"] = null;
                    Session["Username"] = modelMM.Username;
                    Session["Img"] = modelMM.Image.ToString();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Invalid Username or Password!";
                    return View();
                }
            }
            else if (modelMC != null)
            {
                if (modelMC.Password == MC.Password)
                {
                    Session["MC_ID"] = modelMC.ID;
                    Session["S_ID"] = null;
                    Session["MM_ID"] = null;
                    Session["Username"] = modelMC.Username;
                    Session["Img"] = modelMC.Image.ToString();
                    return RedirectToAction("LoadData", "MarketingCoordinators");
                }
                else
                {
                    ViewBag.Error = "Invalid Username or Password!";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Invalid Username or Password!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["S_ID"] = null;
            Session["MM_ID"] = null;
            Session["MC_ID"] = null;
            Session["Username"] = null;
            Session["Img"] = null;
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, string option)
        {
            if (option == null)
            {
                ViewBag.Message = "You are not angree with the Term of Service!";
                return View();
            }

            var s_id = Convert.ToInt32(Session["S_ID"]);
            var student = db.Students.SingleOrDefault(s => s.ID == s_id);
            var marketing_coordinator = db.MarketingCoordinators.SingleOrDefault(a => a.FacultyID == student.FacultiesID);
            
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    var allowedExtensions = new[] { ".pdf", ".doc", ".docx", ".jpeg", ".jpg", ".png", ".gif" };
                    var checkExtension = Path.GetExtension(file.FileName).ToLower();

                    if (!allowedExtensions.Contains(checkExtension))
                    {
                        ViewBag.Message = "Invalid file type!";
                        return View();
                    }

                    string filename = String.Concat(student.FirstName, student.LastName, "_SID", student.ID, "_", student.Faculty.FacultyName, "_", Path.GetFileName(file.FileName));
                    string path = Path.Combine(Server.MapPath("~/Files"), Path.GetFileName(filename));
                    file.SaveAs(path);

                    string type = "";
                    var docType = new[] { ".doc", ".docx", ".pdf" };
                    if (docType.Contains(checkExtension))
                    {
                        type = "Document";
                    }
                    else
                    {
                        type = "Image";
                    }

                    Contribution contribution = new Contribution
                    {
                        StudentID = s_id,
                        Title = Path.GetFileNameWithoutExtension(file.FileName),
                        DateSubmit = DateTime.Now,
                        Type = type,
                        FileType = checkExtension,
                        ArchiveLink = "/Files/" + filename,
                        Status = "Pending"
                    };
                    db.Contributions.Add(contribution);
                    db.SaveChanges();

                    ViewBag.Message = "File uploaded successfully!";

                    SendEmail(marketing_coordinator.Email, s_id);
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error: " + ex.Message.ToString();
                }
            }
            else
            {
                ViewBag.Message = "You have not specified a file!";
            }

            return RedirectToAction("Repository/" + Session["S_ID"], "Students");
        }

        public ActionResult Repository(string id)
        {
            int s_id = Convert.ToInt32(id);
            var files = db.Contributions.Where(f => f.StudentID == s_id).ToList();
            return View(files);
        }

        

        [HttpGet]
        public ActionResult Repositories(string id)
        {
            int s_id = Convert.ToInt32(id);
            var files = db.Contributions.Where(f => f.StudentID == s_id).ToList();
            return View(files);
        }

        [NonAction]
        public void SendEmail(string mc_email, int student_id)
        {
            var student = db.Students.SingleOrDefault(s => s.ID == student_id);

            var fromEmail = new MailAddress("umcsystem@gmail.com");
            var toEmail = new MailAddress(mc_email);
            var fromEmailPassword = "Comp1640";
            string subject = "Student " + student.FirstName + "_SID" + student.ID + "_" + student.Faculty.FacultyName + " has uploaded a file to system!";
            string body = "<p>Click <a href='#'>here</a> to view!";

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
        }
    }
}
