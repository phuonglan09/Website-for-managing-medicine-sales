using System;
using System.Collections.Generic;

namespace Doctors.Base.Models
{
    public partial class Banner
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public bool Homepage { get; set; }
        public bool Servicepage { get; set; }
        public bool Blogpage { get; set; }
        public bool Productpage { get; set; }
    }
}
