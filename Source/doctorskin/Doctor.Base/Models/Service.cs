using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctors.Base.Models
{
    public partial class Service
    {
        public int Id { get; set; }
        public string? NameDt { get; set; }
        public string? DescDt { get; set; }
        public bool HideDt { get; set; }
        public string? ImgDt { get; set; }
        [NotMapped]
        public int TotalRow { get; set; }
    }
}
