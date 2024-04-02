using Doctors.Base;
using Doctorskin.Areas.Admin.Controllers.Base;
using Doctorskin.Areas.Admin.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Areas.Admin.Controllers
{
    public class UserController : BaseController<UserController>
    {
        public UserController(ILogger<UserController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {

        }
        [UserAuthorize(new ActionModule[] { ActionModule.User }, new ActionTypeCustom[] { ActionTypeCustom.View })]
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetUserData(string search, int offset, int limit)
        {
            int total = 0;
            var data = _base.users.GetUserListAllPaging(search, offset, limit);
            if(data != null && data.Count > 0)
            {
                total = data[0].TotalRow;
            }
            return Data(new { rows = data, total = total });
        }
        [UserAuthorize(new ActionModule[] { ActionModule.User }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeIsHide(int Id)
        {
            try
            {
                var entity = _base.users.GetByID(Id);
                if (entity == null)
                {
                    return Error("Thông tin khách hàng không tồn tại");
                }
                entity.Hide = (entity.Hide ? false : true);
                _base.users.Update(entity);
                _base.Commit();
                return Success("Thay đổi trạng thái thành công");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
    }
}
