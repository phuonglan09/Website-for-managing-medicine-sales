using Doctors.Base;
using Doctorskin.Areas.Admin.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Areas.Admin.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
