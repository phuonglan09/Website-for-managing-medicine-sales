using Doctors.Base;
using Doctors.Base.Models;
using Doctorskin.Areas.Admin.Controllers.Base;
using Doctorskin.Areas.Admin.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Areas.Admin.Controllers
{
    public class BookingController : BaseController<BookingController>
    {
        public BookingController(ILogger<BookingController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {

        }
        [UserAuthorize(new ActionModule[] { ActionModule.Booking }, new ActionTypeCustom[] { ActionTypeCustom.View })]
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetBookingListAll(string search, int offset, int limit)
        {
            int total = 0;
            var data = _base.bookings.GetBookingListAllPaging(search, offset, limit);
            if(data != null && data.Count > 0)
            {
                total = data[0].TotalRow;
            }
            return Data(new { rows = data, total = total });
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Booking }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeIsComplete(int Id)
        {
            try
            {
                var entity = _base.bookings.GetByID(Id);
                if(entity == null)
                {
                    return Error("Thông tin lịch đặt không tồn tại");
                }
                entity.Completed = (entity.Completed ? false : true);
                _base.bookings.Update(entity);
                _base.Commit();
                return Success("Thay đổi trạng thái thành công");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Booking }, new ActionTypeCustom[] { ActionTypeCustom.Add, ActionTypeCustom.Edit })]
        public JsonResult CreateOrEdit(Booking model)
        {
            try
            {
                if(string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Phone) || model.Timebooking == null)
                {
                    return Error("Vui lòng nhập đầy đủ thông tin");
                }
                if(model.Id == 0)
                {
                    _base.bookings.Insert(model);
                }
                else
                {
                    var entity = _base.bookings.GetByID(model.Id);
                    if(entity == null)
                    {
                        return Error("Thông tin lịch đặt không tồn tại");
                    }
                    entity.Name = model.Name;
                    entity.Phone = model.Phone;
                    entity.Email = model.Email;
                    entity.Timebooking = model.Timebooking;
                    _base.bookings.Update(entity);
                }
                _base.Commit();
                return Success("Cập nhật thông tin thành công");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }

    }
}
