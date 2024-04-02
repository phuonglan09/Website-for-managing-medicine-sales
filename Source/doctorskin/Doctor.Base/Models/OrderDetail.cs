using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        [NotMapped]
        public string ProductName { get; set; }
        [NotMapped]
        public string ProductImage { get; set; }
        [NotMapped]
        public int TotalRow { get; set; }
    }
}
