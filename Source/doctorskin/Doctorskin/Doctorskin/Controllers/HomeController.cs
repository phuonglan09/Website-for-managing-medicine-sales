using Doctors.Base;
using Doctorskin.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Doctorskin.Controllers
{
    public class HomeController : BaseAuthController<HomeController>
    {
        private readonly IBase _base;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {
            _logger = logger;
            _base = @base;
        }

        public IActionResult Index()
        {
            ViewBag.ListCate = _base.categories.Get(x => x.Hide == false);
            ViewBag.ListBannerHome = _base.banners.Get(x => x.Homepage == true);
            ViewBag.ListDotor = _base.doctors.Get(x => x.HideDoc == false);
            ViewBag.ListBolg = _base.blogDetails.Get(x => x.Hideblog == false).Take(10).ToList();
            return View();
        }
    }
}