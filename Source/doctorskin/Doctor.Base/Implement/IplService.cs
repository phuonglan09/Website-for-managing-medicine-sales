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
    public class IplService: Repository<Service>, IService
    {
        public IConfiguration _configuration { get; }
        internal string _cnnString = string.Empty;
        public DoctorskinCoreContext _dbContext;
        public IplService(DoctorskinCoreContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _cnnString = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<Service> GetServicesListAllPaging(string search, int offset, int limit)
        {
            var list = new List<Service>();
            var unitOfWork = new UnitOfWorkFactory(_cnnString);
            try
            {
                using (var u = unitOfWork.Create(false))
                {
                    var p = new DynamicParameters();
                    p.Add("@search", search);
                    p.Add("@offset", offset);
                    p.Add("@limit", limit);
                    list = u.GetIEnumerable<Service>("Sp_GetServiceListAllPaging", p).ToList();
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
