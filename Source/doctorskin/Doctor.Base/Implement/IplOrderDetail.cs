using BaseRepo.Repositories;
using Dapper;
using Doctors.Base.Interface;
using Doctors.Base.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base.Implement
{
    public class IplOrderDetail: Repository<OrderDetail>, IOrderDetail
    {
        public IConfiguration _configuration { get; }
        internal string _cnnString = string.Empty;
        public DoctorskinCoreContext _dbContext;
        public IplOrderDetail(DoctorskinCoreContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _cnnString = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<OrderDetail> GetOrderDetailByOrderIdListAll(int orderId, int offset, int limit)
        {
            var list = new List<OrderDetail>();
            var unitOfWork = new UnitOfWorkFactory(_cnnString);
            try
            {
                using (var u = unitOfWork.Create(false))
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", orderId);
                    p.Add("@offset", offset);
                    p.Add("@limit", limit);
                    list = u.GetIEnumerable<OrderDetail>("Sp_GetOrderDetailByOrderId", p).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }
    }
}
