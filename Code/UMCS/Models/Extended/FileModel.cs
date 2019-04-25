using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMCS.Models.Extended
{
    public class FileModel
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public bool IsSelected { get; set; }
    }
}