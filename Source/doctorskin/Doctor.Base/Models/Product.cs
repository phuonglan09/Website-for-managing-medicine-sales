using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctors.Base.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Namep { get; set; }
        public int CateId { get; set; }
        public decimal Newprice { get; set; }
        public decimal Oldprice { get; set; }
        public string Descr { get; set; } = null!;
        public bool Hide { get; set; }
        public string Statep { get; set; } = null!;
        public string? Img { get; set; }
        public DateTime? DateUp { get; set; }
        public int Idbrand { get; set; }
        public string? Avilability { get; set; }
        public string? Rated { get; set; }
        public string? Listimg { get; set; }
        [NotMapped]
        public int TotalRow { get; set; }
        [NotMapped]
        public string Namebrand { get; set; }
        [NotMapped]
        public string Namec { get; set; }
    }
    public class Setting
    {
        public string Value { get; set; }
        public string DisplayName { get; set; }
    }
    public class SortModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
    }
}
