using BaseRepo.Interfaces;
using Doctors.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base.Interface
{
    public interface IOrderDetail: IRepository<OrderDetail>
    {
        List<OrderDetail> GetOrderDetailByOrderIdListAll(int orderId, int offset, int limit);
    }
}
