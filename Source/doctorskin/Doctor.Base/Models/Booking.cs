using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctors.Base.Models
{
    public partial class Booking
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Require { get; set; }
        public DateTime? Timebooking { get; set; }
        public bool Completed { get; set; }
        [NotMapped]
        public int TotalRow { get; set; }
    }
}
