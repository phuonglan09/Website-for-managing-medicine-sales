using BaseRepo.Interfaces;
using Doctors.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base.Interface
{
    public interface IServiceDetail: IRepository<ServicesDetail>
    {
        List<ServicesDetail> GetServiceDetailListAll(int serviceId, string search, int offset, int limit);
    }
}
