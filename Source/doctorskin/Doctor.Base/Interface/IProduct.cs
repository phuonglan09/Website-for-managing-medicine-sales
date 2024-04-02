using BaseRepo.Interfaces;
using Doctors.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base.Interface
{
    public interface IProduct: IRepository<Product>
    {
        List<Product> GetProductListAll(string search, int offset, int limit);
        List<Product> GetProductSelling();
        List<Product> GetProductListBySort(int sort, int offset, int limit);
        Product GetProductById(int Id);
        List<Product> GetProductListByCateId(int cateId, int offset, int limit);
    }
}
