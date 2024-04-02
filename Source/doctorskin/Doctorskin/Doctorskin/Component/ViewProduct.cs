using Doctors.Base;
using Doctors.Base.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Component
{
    public class ViewProduct: ViewComponent
    {
        private IBase _base;
        public ViewProduct(IBase @base)
        {
            _base = @base;
        }
        public IViewComponentResult Invoke(int cateId)
        {
            List<Product> model = _base.products.Get(x => x.CateId == cateId && x.Hide == false).ToList();
            return View(model);
        }
    }
}
