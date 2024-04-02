using BaseRepo.Interfaces;
using Doctors.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base.Interface
{
    public interface IOrder: IRepository<Order>
    {
        int InserOrder(Order order); 
        List<Order> GetOrderListAllPaging(string search, int status, int offset, int limit);
    }
}
