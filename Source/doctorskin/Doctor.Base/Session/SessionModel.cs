using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base.Session
{
    public class AdminSession
    {
        public string SessionId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
    }
    public class CustomerSession
    {
        public string SessionId { get; set; }
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
    }
    public class CartObject
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string Images { get; set; }
    }
}
