using Doctors.Base;
using Doctorskin.Areas.Admin.Controllers.Base;
using Doctorskin.Areas.Admin.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Areas.Admin.Controllers
{
    public class OrderController : BaseController<OrderController>
    {
        public OrderController(ILogger<OrderController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {

        }
        [UserAuthorize(new ActionModule[] { ActionModule.Order }, new ActionTypeCustom[] { ActionTypeCustom.View })]
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetOrderData(string search, int status, int offset, int limit)
        {
            int total = 0;
            var data = _base.orders.GetOrderListAllPaging(search, status, offset, limit);
            if(data != null && data.Count > 0)
            {
                total = data[0].TotalRow;
            }
            return Data(new { rows = data, total = total });
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Order }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeStatus(int Id, int status)
        {
            try
            {
                var entity = _base.orders.GetByID(Id);
                if(entity == null)
                {
                    return Error("Thông tin đơn hàng không tồn tại");
                }
                entity.Status = status;
                _base.orders.Update(entity);
                _base.Commit();
                return Success("Thay đổi trạng thái thành công");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Order }, new ActionTypeCustom[] { ActionTypeCustom.View })]
        public IActionResult OrderDetail(int Id)
        {
            var model = _base.orders.GetByID(Id);
            return View(model);
        }
        public JsonResult GetOrderDetail(int orderId, int offset, int limit)
        {
            int total = 0;
            var data = _base.orderDetails.GetOrderDetailByOrderIdListAll(orderId, offset, limit);
            if(data != null && data.Count > 0)
            {
                total = data[0].TotalRow;
            }
            return Data(new { rows = data, total = total });
        }
    }
}
