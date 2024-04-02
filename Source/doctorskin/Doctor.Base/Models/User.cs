using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctors.Base.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Birth { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool Hide { get; set; }
        public string? Ava { get; set; }
        public DateTime? Dateregist { get; set; }
        [NotMapped]
        public int TotalRow { get; set; }
    }
}
