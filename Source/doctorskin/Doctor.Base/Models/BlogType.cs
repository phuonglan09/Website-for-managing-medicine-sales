using System;
using System.Collections.Generic;

namespace Doctors.Base.Models
{
    public partial class BlogType
    {
        public int Id { get; set; }
        public string Namebt { get; set; } = null!;
        public bool Hide { get; set; }
    }
}
