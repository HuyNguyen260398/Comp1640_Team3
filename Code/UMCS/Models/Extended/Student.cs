using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UMCS.Models
{
    [MetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
        public HttpPostedFileBase ImageFile { get; set; }
    }

    public class StudentMetadata
    {
        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

        [Display(Name = "Upload Image")]
        public string Image { get; set; }
    }
}