using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UMCS.Models.Extended
{
    public class ReportModel
    {
        [Required]
        [Display(Name = "Faculties ID")]
        public int FacultyId { get; set; }

        [Required]
        [Display(Name = "Faculties Name")]
        public string FacultyName { get; set; }

        [Display(Name = "Number of Contribution")]
        public int NumberOfContribution { get; set; }

        [Display(Name = "Percent of Contribution")]
        public string PercentOfContribution { get; set; }

        [Display(Name = "Number of Contributor")]
        public int NumberOfContributor { get; set; }
    }
}