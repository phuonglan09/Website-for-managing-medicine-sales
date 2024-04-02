using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctors.Base.Models
{
    public partial class Brand
    {
        public int Id { get; set; }
        public string? Namebrand { get; set; }
        public bool Hidebrand { get; set; }
        [NotMapped]
        public int TotalRow { get; set; }
    }
}
