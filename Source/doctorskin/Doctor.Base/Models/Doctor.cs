using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctors.Base.Models
{
    public partial class Doctor
    {
        public int Id { get; set; }
        public string? Namedoc { get; set; }
        public string? Infordoc { get; set; }
        public string? AvaDoc { get; set; }
        public bool HideDoc { get; set; }
        public DateTime? DateUpDoc { get; set; }
        [NotMapped]
        public int TotalRow { get; set; }
    }
}
