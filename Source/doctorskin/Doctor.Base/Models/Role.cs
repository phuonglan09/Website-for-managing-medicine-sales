using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base.Models
{
    public class Role
    {
        public int Id { get; set; }
        public int RoleGroupId { get; set; }
        public int ModuleId { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool View { get; set; }
        public bool Confirm { get; set; }
        [NotMapped]
        public string ModuleName { get; set; }
    }
}
