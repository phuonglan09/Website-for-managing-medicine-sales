using BaseRepo.Interfaces;
using Doctors.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base.Interface
{
    public interface IService: IRepository<Service>
    {
        List<Service> GetServicesListAllPaging(string search, int offset, int limit);
    }
}
