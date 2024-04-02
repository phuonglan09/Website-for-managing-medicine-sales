using Doctors.Base;
using Doctors.Base.Models;
using Doctorskin.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Controllers
{
    public class BookingController : BaseAuthController<BookingController>
    {
        private readonly IBase _base;
        public BookingController(ILogger<BookingController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {
            _logger = logger;
            _base = @base;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult SubBooking(Booking model)
        {
            try
            {
                if(string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Phone) || model.Timebooking == null)
                {
                    return Error("Vui lòng nhập đầy đủ thông tin");
                }
                _base.bookings.Insert(model);
                _base.Commit();
                return Success("Đặt lịch khám và tư vấn thành công");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
    }
}
