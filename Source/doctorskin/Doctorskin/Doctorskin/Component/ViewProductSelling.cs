using Doctors.Base.Models;
using Doctors.Base;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Component
{
    public class ViewProductSelling: ViewComponent
    {
        private IBase _base;
        public ViewProductSelling(IBase @base)
        {
            _base = @base;
        }
        public IViewComponentResult Invoke(int cateId)
        {
            List<Product> model = _base.products.GetProductSelling();
            return View(model);
        }
    }
}
