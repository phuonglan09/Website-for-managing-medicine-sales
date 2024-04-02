using Doctors.Base;
using Doctorskin.Controllers.Base;
using Doctorskin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Controllers
{
    public class SearchController : BaseAuthController<SearchController>
    {
        private readonly IBase _base;
        public SearchController(ILogger<SearchController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {
            _logger = logger;
            _base = @base;
        }
        public IActionResult Index(string search)
        {
            var model = new SearchModel();
            if (!string.IsNullOrEmpty(search))
            {
                model.ListProduct = _base.products.GetProductListAll(search, 0, 999999);
                model.ListDoctor = _base.doctors.GetDoctorListAllPaging(search, 0, 999999);
            }
            ViewBag.Search = search;    
            return View(model);
        }
    }
}
