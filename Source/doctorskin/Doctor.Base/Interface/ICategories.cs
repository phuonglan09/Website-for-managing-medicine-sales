using BaseRepo.Interfaces;
using Doctors.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctors.Base.Interface
{
    public interface ICategories: IRepository<Category>
    {
        List<Category> GetCategoriesListAll(string search, int offset, int limit);
    }
}
