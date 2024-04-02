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
    public class IplProduct: Repository<Product>, IProduct
    {
        public IConfiguration _configuration { get; }
        internal string _cnnString = string.Empty;
        public DoctorskinCoreContext _dbContext;
        public IplProduct(DoctorskinCoreContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _cnnString = _configuration.GetConnectionString("DefaultConnection");
        }

        public List<Product> GetProductListAll(string search, int offset, int limit)
        {
            var list = new List<Product>();
            var unitOfWork = new UnitOfWorkFactory(_cnnString);
            try
            {
                using (var u = unitOfWork.Create(false))
                {
                    var p = new DynamicParameters();
                    p.Add("@search", search);
                    p.Add("@offset", offset);
                    p.Add("@limit", limit);
                    list = u.GetIEnumerable<Product>("Sp_GetProductListAllPaging", p).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }

        public List<Product> GetProductSelling()
        {
            var list = new List<Product>();
            var unitOfWork = new UnitOfWorkFactory(_cnnString);
            try
            {
                using (var u = unitOfWork.Create(false))
                {
                    list = u.GetIEnumerable<Product>("Sp_GetProductSelling").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }

        public List<Product> GetProductListBySort(int sort, int offset, int limit)
        {
            var list = new List<Product>();
            var unitOfWork = new UnitOfWorkFactory(_cnnString);
            try
            {
                using (var u = unitOfWork.Create(false))
                {
                    var p = new DynamicParameters();
                    p.Add("@sort", sort);
                    p.Add("@offset", offset);
                    p.Add("@limit", limit);
                    list = u.GetIEnumerable<Product>("Sp_GetListProductSort", p).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }

        public Product GetProductById(int Id)
        {

            var data = new Product();
            var unitOfWork = new UnitOfWorkFactory(_cnnString);
            try
            {
                using (var u = unitOfWork.Create(false))
                {
                    var p = new DynamicParameters();
                    p.Add("@Id", Id);
                    data = u.GetIEnumerable<Product>("Sp_GetProduct_ById", p).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return data;
        }

        public List<Product> GetProductListByCateId(int cateId, int offset, int limit)
        {
            var list = new List<Product>();
            var unitOfWork = new UnitOfWorkFactory(_cnnString);
            try
            {
                using (var u = unitOfWork.Create(false))
                {
                    var p = new DynamicParameters();
                    p.Add("@CateId", cateId);
                    p.Add("@offset", offset);
                    p.Add("@limit", limit);
                    list = u.GetIEnumerable<Product>("Sp_GetProductByCateId", p).ToList();
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
