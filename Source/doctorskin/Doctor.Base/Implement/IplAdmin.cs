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
    public class IplAdmin: Repository<Admin>, IAdmin
    {
        public IConfiguration _configuration { get; set; }
        internal string _cnnString = string.Empty;
        public DoctorskinCoreContext _dbContext;
        public IplAdmin(DoctorskinCoreContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _cnnString = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<Admin> GetAdminListAll(string search, int offset, int limit)
        {
            var list = new List<Admin>();
            var unitOfWork = new UnitOfWorkFactory(_cnnString);
            try
            {
                using (var u = unitOfWork.Create(false))
                {
                    var p = new DynamicParameters();
                    p.Add("@search", search);
                    p.Add("@offset", offset);
                    p.Add("@limit", limit);
                    list = u.GetIEnumerable<Admin>("Sp_GetAdminListAll", p).ToList();
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
