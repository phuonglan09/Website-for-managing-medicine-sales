using Doctors.Base.Implement;
using Doctors.Base.Interface;
using Doctors.Base.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base
{
    public class IplBase : IBase
    {
        #region contructor
        private DoctorskinCoreContext _dbContext;
        public IConfiguration _configuration { get; }    

        public IplBase(DoctorskinCoreContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        #endregion
        #region repository
        private IServiceDetail _serviceDetailRepo;
        public IServiceDetail serviceDetail
        {
            get
            {
                return _serviceDetailRepo ?? (_serviceDetailRepo = new IplServiceDetail(_dbContext, _configuration));
            }
        }
        private IService _serviceRepo;
        public IService services
        {
            get
            {
                return _serviceRepo ?? (_serviceRepo = new IplService(_dbContext, _configuration));
            }
        }
        private IProduct _products;
        public IProduct products
        {
            get
            {
                return _products ?? (_products = new IplProduct(_dbContext, _configuration));
            }
        }
        private ICategories _categories;
        public ICategories categories
        {
            get
            {
                return _categories ?? (_categories = new IplCategories(_dbContext, _configuration));
            }
        }
        private IBrand _brands;
        public IBrand brands
        {
            get
            {
                return _brands ?? (_brands = new IplBrand(_dbContext, _configuration));
            }
        }
        private IBlogType _blogTypes;
        public IBlogType blogTypes
        {
            get
            {
                return _blogTypes ?? (_blogTypes = new IplBlogType(_dbContext, _configuration));
            }
        }
        private IBlogDetail _blogDetails;
        public IBlogDetail blogDetails
        {
            get
            {
                return _blogDetails ?? (_blogDetails = new IplBlogDetail(_dbContext, _configuration));
            }
        }
        private Interface.IUser _users;
        public Interface.IUser users
        {
            get
            {
                return _users ?? (_users = new IplUser(_dbContext, _configuration));
            }
        }
        private IOrder _orders;
        public IOrder orders
        {
            get
            {
                return _orders ?? (_orders = new IplOrder(_dbContext, _configuration));
            }
        }
        private IOrderDetail _orderDetails;
        public IOrderDetail orderDetails
        {
            get
            {
                return _orderDetails ?? (_orderDetails = new IplOrderDetail(_dbContext, _configuration));
            }
        }
        private IBooking _bookings;
        public IBooking bookings
        {
            get
            {
                return _bookings ?? (_bookings = new IplBooking(_dbContext, _configuration));
            }
        }
        private IDoctor _doctors;
        public IDoctor doctors
        {
            get
            {
                return _doctors ?? (_doctors = new IplDoctor(_dbContext, _configuration));
            }
        }
        private IBanner _banners;
        public IBanner banners
        {
            get
            {
                return _banners ?? (_banners = new IplBanner(_dbContext, _configuration));
            }
        }
        private IAdmin _admins;
        public IAdmin admins
        {
            get
            {
                return _admins ?? (_admins = new IplAdmin(_dbContext, _configuration));
            }
        }
        private IRole _roles;
        public IRole roles
        {
            get
            {
                return _roles ?? (_roles = new IplRole(_dbContext, _configuration));
            }
        }
        private IRoleGroup _roleGroup;
        public IRoleGroup roleGroups
        {
            get
            {
                return _roleGroup ?? (_roleGroup = new IplRoleGroup(_dbContext, _configuration));
            }
        }
        private ICart _carts;
        public ICart carts
        {
            get
            {
                return _carts ?? (_carts = new IplCart(_dbContext, _configuration));
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        #endregion
    }
}
