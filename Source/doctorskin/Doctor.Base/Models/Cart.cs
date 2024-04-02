using System;
using System.Collections.Generic;

namespace Doctors.Base.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int Iduser { get; set; }
        public int Idp { get; set; }
        public int Quantity { get; set; }
    }
}
