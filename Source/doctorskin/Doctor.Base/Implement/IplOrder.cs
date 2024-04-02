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
    public class IplOrder: Repository<Order>, IOrder
    {
        public IConfiguration _configuration { get; }
        internal string _cnnString = string.Empty;
        public DoctorskinCoreContext _dbContext;
        public IplOrder(DoctorskinCoreContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _cnnString = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<Order> GetOrderListAllPaging(string search, int status, int offset, int limit)
        {
            var list = new List<Order>();
            var unitOfWork = new UnitOfWorkFactory(_cnnString);
            try
            {
                using (var u = unitOfWork.Create(false))
                {
                    var p = new DynamicParameters();
                    p.Add("@search", search);
                    p.Add("@status", status);
                    p.Add("@offset", offset);
                    p.Add("@limit", limit);
                    list = u.GetIEnumerable<Order>("Sp_GetOrderListAllPaging", p).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }

        public int InserOrder(Order order)
        {
            var unitOfWork = new UnitOfWorkFactory(_cnnString);
            try
            {
                using (var u = unitOfWork.Create(true))
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderCode", order.OrderCode);
                    p.Add("@UserId", order.UserId);
                    p.Add("@TotalAmount", order.TotalAmount);
                    p.Add("@Status", order.Status);
                    p.Add("@OrderCode", order.OrderCode);
                    p.Add("@PhoneNumber", order.PhoneAddress);
                    p.Add("@Address", order.Address);
                    p.Add("@NewId", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);
                    var result = u.ProcedureExecute("Sp_InsertOrder", p);
                    if(result > 0)
                    {
                        return p.Get<int>("@NewId");
                    }
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
