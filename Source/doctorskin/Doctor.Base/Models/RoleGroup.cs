﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base.Models
{
    public class RoleGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public int TotalRow { get; set; }
    }
}