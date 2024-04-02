using Doctors.Base;
using Doctors.Base.Models;
using Doctorskin.Areas.Admin.Controllers.Base;
using Doctorskin.Areas.Admin.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Areas.Admin.Controllers
{
    public class RoleGroupController : BaseController<RoleGroupController>
    {
        public RoleGroupController(ILogger<RoleGroupController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {

        }
        [UserAuthorize(new ActionModule[] { ActionModule.RoleGroup }, new ActionTypeCustom[] { ActionTypeCustom.View })]
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetRoleGroupData(string search, int offset, int limit)
        {
            int total = 0;
            var data = _base.roleGroups.GetRoleGroupListAll(search, offset, limit);
            if (data != null && data.Count > 0)
            {
                total = data[0].TotalRow;
            }
            return Data(new { rows = data, total = total });
        }
        [UserAuthorize(new ActionModule[] { ActionModule.RoleGroup }, new ActionTypeCustom[] { ActionTypeCustom.Add, ActionTypeCustom.Edit })]
        public JsonResult CreateOrEdit(RoleGroup model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name))
                {
                    return Error("Vui lòng nhập tên nhóm quyền");
                }
                var ckName = _base.roleGroups.Read(x => x.Name.Equals(model.Name.Trim()) && x.Id != model.Id);
                if(ckName != null)
                {
                    return Error("Tên nhóm quyền đã tồn tại");
                }
                if(model.Id == 0)
                {
                    _base.roleGroups.Insert(model);
                }
                else
                {
                    var entity = _base.roleGroups.GetByID(model.Id);
                    if(entity == null)
                    {
                        return Error("Thông tin nhóm quyền không tồn tại");
                    }
                    entity.Name = model.Name;
                    _base.roleGroups.Update(entity);
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
