using Doctors.Base;
using Doctors.Base.Models;
using Doctorskin.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Doctorskin.Controllers
{
    public class ProductController : BaseAuthController<ProductController>
    {
        private readonly IBase _base;
        public ProductController(ILogger<ProductController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {
            _logger = logger;
            _base = @base;
        }
        public IActionResult Index(int? page, int sort)
        {
            int total = 0;
            ViewDefault();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            int startIndex = (pageNumber - 1) * pageSize;
            List<Product> model = _base.products.GetProductListBySort(sort, startIndex, pageSize);
            if(model != null && model.Count > 0)
            {
                total = model[0].TotalRow;
            }
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling((double)total / pageSize);
            ViewBag.Sort = sort;
            return View(model);
        }
        public IActionResult Detail(int Id)
        {
            Product model = _base.products.GetProductById(Id);
            List<Product> lstProductReletad = new List<Product>();
            if(model != null)
            {
                lstProductReletad = _base.products.GetProductListByCateId(model.CateId, 0, 999999);
            }
            ViewBag.ProductReletad = lstProductReletad;
            return View(model);
        }
        public void ViewDefault()
        {
            ViewBag.Banner = _base.banners.Get(x => x.Productpage == true).OrderByDescending(x => x.Id).FirstOrDefault();
        }
    }
}
