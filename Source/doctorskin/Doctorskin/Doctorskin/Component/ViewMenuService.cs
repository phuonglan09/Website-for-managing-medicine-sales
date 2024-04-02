using Doctors.Base.Models;
using Doctors.Base;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Component
{
    public class ViewMenuService : ViewComponent
    {
        private IBase _base;
        public ViewMenuService(IBase @base)
        {
            _base = @base;
        }
        public IViewComponentResult Invoke()
        {
            List<Service> model = _base.services.Get(x => x.HideDt == false).ToList();
            return View(model);
        }
    }
}
