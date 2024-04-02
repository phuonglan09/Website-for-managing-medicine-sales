using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }    
        public int Status { get; set; }
        public bool Userfb { get; set; }
        public string? PhoneAddress { get; set; }
        public string? Address { get; set; }
        [NotMapped]
        public int TotalRow { get; set; }
        [NotMapped]
        public string FullName { get; set; }
        [NotMapped]
        public string VoucherName { get; set; }
    }
}
