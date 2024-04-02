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
    public class IplRole: Repository<Role>, IRole
    {
        public IConfiguration _configuration { get; }
        internal string _cnnString = string.Empty;
        public DoctorskinCoreContext _dbContext;
        public IplRole(DoctorskinCoreContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _cnnString = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<Role> GetRoleListAllByRoleGroupId(int roleGroupId)
        {
            var list = new List<Role>();
            var unitOfWork = new UnitOfWorkFactory(_cnnString);
            try
            {
                using (var u = unitOfWork.Create(false))
                {
                    var p = new DynamicParameters();
                    p.Add("@roleGroupId", roleGroupId);
                    list = u.GetIEnumerable<Role>("Sp_GetRole_ListAll", p).ToList();
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
