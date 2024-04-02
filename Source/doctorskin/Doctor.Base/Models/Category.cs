using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctors.Base.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public string? Namec { get; set; }
        public bool Hide { get; set; }
        public DateTime? DateUp { get; set; }
        [NotMapped]
        public int TotalRow { get; set; }
    }
}
