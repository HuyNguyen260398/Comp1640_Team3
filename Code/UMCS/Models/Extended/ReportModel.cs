using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMCS.Models.Extended
{
    public class ReportModel
    {
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public int NumberOfContribution { get; set; }
        public float PercentOfContribution { get; set; }
        public int NumberOfContributor { get; set; }
    }
}