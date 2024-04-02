using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctors.Base.Models
{
    public partial class ServicesDetail
    {
        public int Id { get; set; }
        public string? NameSd { get; set; }
        public string? ImgSd { get; set; }
        public bool HideSd { get; set; }
        public decimal PriceSd { get; set; }
        public int IdDt { get; set; }
        public string? DescDe { get; set; }
        public int Amount { get; set; }
        [NotMapped]
        public int TotalRow { get; set; }
    }
}
