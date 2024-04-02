using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UnauthorisedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
