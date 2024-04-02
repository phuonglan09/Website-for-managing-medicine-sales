using Doctors.Base;
using Doctorskin.Controllers.Base;
using Doctorskin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Controllers
{
    public class ServiceController : BaseAuthController<ServiceController>
    {
        private readonly IBase _base;
        public ServiceController(ILogger<ServiceController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {
            _logger = logger;
            _base = @base;
        }
        public IActionResult Index(int Id)
        {
            ServiceModel model = new ServiceModel();
            model.Service = _base.services.GetByID(Id);
            model.ListServiceDetail = _base.serviceDetail.Get(x => x.IdDt == Id && x.HideSd == false).ToList();
            return View(model);
        }
    }
}
