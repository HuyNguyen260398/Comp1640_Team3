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

    public partial class Contribution
    {
        public int ID { get; set; }
        public Nullable<int> StudentID { get; set; }
        public string Title { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public Nullable<System.DateTime> DateSubmit { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public Nullable<System.DateTime> LastUpdate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public Nullable<System.DateTime> CommentDate { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string FileType { get; set; }
        public string ArchiveLink { get; set; }
        public string Status { get; set; }
        public Nullable<int> FID { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
