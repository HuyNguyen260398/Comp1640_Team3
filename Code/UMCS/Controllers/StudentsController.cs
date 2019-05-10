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
using PagedList;

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
        public ActionResult Login(Student student, MarketingManager MM, Faculty1 MC, Administrator admin)
        {
            var model = db.Students.SingleOrDefault(s => s.Username == student.Username);
            var modelMM = db.MarketingManagers.SingleOrDefault(mm => mm.Username == MM.Username);
            var modelF = db.Faculties1.SingleOrDefault(mc => mc.Username == MC.Username);
            var modelAdmin = db.Administrators.SingleOrDefault(a => a.Username == admin.Username);

            if (model != null)
            {
                if (model.Password == student.Password)
                {
                    Session["S_ID"] = model.ID;
                    Session["MM_ID"] = null;
                    Session["MC_ID"] = null;
                    Session["F_ID"] = null;
                    Session["Username"] = model.Username;
                    Session["Img"] = model.Image.ToString();
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
                    Session["Admin_Username"] = null;
                    Session["Img"] = modelMM.Image.ToString();
                    return RedirectToAction("Index", "MarketingManagers");
                }
                else
                {
                    ViewBag.Error = "Invalid Username or Password!";
                    return View();
                }
            }
            else if (modelF != null)
            {
                if (modelF.Password == MC.Password && modelF.Role == "Marketing Coordinator")
                {
                    Session["MC_ID"] = modelF.ID;
                    Session["S_ID"] = null;
                    Session["MM_ID"] = null;
                    Session["F_ID"] = null;
                    Session["Username"] = modelF.Username;
                    Session["Admin_Username"] = null;
                    Session["f"] = modelF.FacultiesID;
                    Session["Img"] = modelF.Image.ToString();
                    return RedirectToAction("LoadData", "MarketingCoordinators");
                }
                else if (modelF.Password == MC.Password && modelF.Role == "Faculty") {
                    Session["F_ID"] = modelF.ID;
                    Session["MC_ID"] = null;
                    Session["S_ID"] = null;
                    Session["MM_ID"] = null;
                    Session["Username"] = modelF.Username;
                    Session["Admin_Username"] = null;
                    Session["Img"] = modelF.Image.ToString();
                    return RedirectToAction("ShowStatistic", "Faculty1");
                }
                else
                {
                    ViewBag.Error = "Invalid Username or Password!";
                    return View();
                }
            }
            else if (modelAdmin != null)
            {
                if (modelAdmin.Password == admin.Password)
                {
                    Session["Admin_Username"] = modelAdmin.Username;
                    Session["F_ID"] = null;
                    Session["MC_ID"] = null;
                    Session["S_ID"] = null;
                    Session["MM_ID"] = null;
                    return RedirectToAction("SetClosureDate", "Admin");
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
            Session["F_ID"] = null;
            Session["Admin_Username"] = null;
            Session["Username"] = null;
            Session["Img"] = null;
            Session["Admin_Username"] = null;
            Session["f"] = null;
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Upload()
        {
            var currentYear = DateTime.Now.Year;
            var currentDate = DateTime.Now.Date;
            var closureDate = db.ClosureDates.SingleOrDefault(c => c.AcademicYear == currentYear).ClosureDate1;

            if (closureDate == null)
            {
                ViewBag.Deadline = "Closure date has not been set! New contributions are disabled!";
            } else if (currentDate > closureDate)
            {
                ViewBag.Deadline = "Closure date is passed! New contributions are disabled!";
            }

            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, string option)
        {

            if (option == null)
            {
                ViewBag.Error = "You are not angree with the Term of Service!";
                return View();
            }

            var s_id = Convert.ToInt32(Session["S_ID"]);
            var student = db.Students.SingleOrDefault(s => s.ID == s_id);
            var marketing_coordinator = db.Faculties1.Where(a => a.FacultiesID == student.FacultiesID && a.Role == "Marketing Coordinator").SingleOrDefault();
            
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    var allowedExtensions = new[] { ".pdf", ".doc", ".docx", ".jpeg", ".jpg", ".png", ".gif" };
                    var checkExtension = Path.GetExtension(file.FileName).ToLower();

                    if (!allowedExtensions.Contains(checkExtension))
                    {
                        ViewBag.Error = "Invalid file type!";
                        return View();
                    }

                    string title = String.Concat(student.FirstName, student.LastName, "_SID", student.ID, "_", student.Faculty.FacultyName, "_", Path.GetFileNameWithoutExtension(file.FileName));
                    string filename = String.Concat(title, checkExtension);
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
                        Title = title,
                        DateSubmit = DateTime.Now,
                        LastUpdate = DateTime.Now,
                        Type = type,
                        FileType = checkExtension,
                        ArchiveLink = path,
                        Status = "Pending",
                        FID = student.FacultiesID
                    };
                    db.Contributions.Add(contribution);
                    db.SaveChanges();

                    ViewBag.Message = "File uploaded successfully!";

                    SendEmail(marketing_coordinator.Email, s_id);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Error: " + ex.Message.ToString();
                }
            }
            else
            {
                ViewBag.Error = "You have not specified a file!";
            }

            
            return View();
        }

        public FileResult Download(string FilePath)
        {
            var FileVirtualPath = "~/Files/" + FilePath;
            return File(FileVirtualPath, "application/force- download", Path.GetFileName(FileVirtualPath));
        }

        public ActionResult Repository(string id, int? page, string fileName, DateTime? submitDate, string type, string status)
        {
            List<SelectListItem> list1 = new List<SelectListItem>();
            list1.Add(new SelectListItem { Text = "File Type", Value = "refresh" });
            list1.Add(new SelectListItem { Text = "Document", Value = "Document" });
            list1.Add(new SelectListItem { Text = "Image", Value = "Image" });

            ViewBag.Type = list1;

            List<SelectListItem> list2 = new List<SelectListItem>();
            list2.Add(new SelectListItem { Text = "Upload Status", Value = "refresh" });
            list2.Add(new SelectListItem { Text = "Pending", Value = "Pending" });
            list2.Add(new SelectListItem { Text = "Commented", Value = "Commented" });
            list2.Add(new SelectListItem { Text = "Selected", Value = "Selected" });
            list2.Add(new SelectListItem { Text = "Unselected", Value = "Unselected" });

            ViewBag.Status = list2;

            int s_id = Convert.ToInt32(id);
            var files = db.Contributions.Where(f => f.StudentID == s_id).AsQueryable();

            if (!String.IsNullOrEmpty(fileName))
            {
                files = files.Where(n => n.Title.Contains(fileName));
            }

            if (!String.IsNullOrEmpty(submitDate.ToString()))
            {
                files = files.Where(d => d.DateSubmit == submitDate);
            }

            if (type != null && type != "refresh")
            {
                files = files.Where(t => t.Type.Equals(type));
            }

            if (status != null && status != "refresh")
            {
                files = files.Where(t => t.Status.Equals(status));
            }

            return View(files.OrderByDescending(o => o.DateSubmit).ToPagedList(page ?? 1, 8));
        }
        

        [NonAction]
        public void SendEmail(string mc_email, int student_id)
        {
            var student = db.Students.SingleOrDefault(s => s.ID == student_id);

            var fromEmail = new MailAddress("umcsystem@gmail.com");
            var toEmail = new MailAddress(mc_email);
            var fromEmailPassword = "Comp1640";
            string subject = "[Student Name] " + student.FirstName + "_[SID] " + student.ID + "_[Faculties] " + student.Faculty.FacultyName + " has uploaded a file to system!";
            string body = "Please send a comment email to reply this contribution within <b>14 days</b>";

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
