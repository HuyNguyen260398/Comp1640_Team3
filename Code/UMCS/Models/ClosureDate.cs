//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UMCS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ClosureDate
    {
        public int ID { get; set; }

        [Display(Name = "Academic Year")]
        public Nullable<int> AcademicYear { get; set; }

        [Display(Name = "Closure Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public Nullable<System.DateTime> ClosureDate1 { get; set; }

        [Display(Name = "Final Closure Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public Nullable<System.DateTime> FinalClosureDate { get; set; }
    }
}
