﻿using BaseRepo.Interfaces;
using Doctors.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base.Interface
{
    public interface IAdmin: IRepository<Admin>
    {
        List<Admin> GetAdminListAll(string search, int offset, int limit);
    }
}
