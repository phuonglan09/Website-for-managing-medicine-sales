using Doctors.Base;
using Doctors.Base.Models;
using Doctorskin.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Controllers
{
    public class CategoryController : BaseAuthController<CategoryController>
    {
        private readonly IBase _base;
        public CategoryController(ILogger<CategoryController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {
            _logger = logger;
            _base = @base;
        }
        public IActionResult Index(int Id, int? page)
        {
            ViewDefault();
            int total = 0;
            int pageSize = 10;
            int pageNumber = page ?? 1;
            int startIndex = (pageNumber - 1) * pageSize;
            List<Product> model = _base.products.GetProductListByCateId(Id, startIndex, pageSize);
            if(model != null && model.Count > 0)
            {
                total = model[0].TotalRow;
            }
            ViewBag.CateId = Id;
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling((double)total / pageSize);
            return View(model);
        }
        public void ViewDefault()
        {
            ViewBag.Banner = _base.banners.Get(x => x.Productpage == true).OrderByDescending(x => x.Id).FirstOrDefault();
        }
    }
}
