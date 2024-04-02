using BaseRepo.Repositories;
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
    public class IplCart: Repository<Cart>, ICart
    {
        public IConfiguration _configuration { get; }
        internal string _cnnString = string.Empty;
        public DoctorskinCoreContext _dbContext;
        public IplCart(DoctorskinCoreContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _cnnString = _configuration.GetConnectionString("DefaultConnection");
        }
    }
}
