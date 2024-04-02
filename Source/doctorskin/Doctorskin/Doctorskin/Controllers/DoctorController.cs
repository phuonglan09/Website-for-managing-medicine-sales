using Doctors.Base;
using Doctors.Base.Models;
using Doctorskin.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Controllers
{
    public class DoctorController : BaseAuthController<DoctorController>
    {
        private readonly IBase _base;
        public DoctorController(ILogger<DoctorController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {
            _logger = logger;
            _base = @base;
        }
        public IActionResult Index(int? page)
        {
            int pageSize = 9;
            int total = 0;
            int pageNumber = page ?? 1;
            int startIndex = (pageNumber - 1) * pageSize;
            List<Doctor> model = _base.doctors.GetDoctorListAllPaging(null, startIndex, pageSize);
            if(model != null && model.Count > 0)
            {
                total = model[0].TotalRow;
            }
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling((double)total / pageSize);
            return View(model);
        }
    }
}
