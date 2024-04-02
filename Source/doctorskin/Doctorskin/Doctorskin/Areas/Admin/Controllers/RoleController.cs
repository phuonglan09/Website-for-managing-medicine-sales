using Doctors.Base;
using Doctors.Base.Models;
using Doctorskin.Areas.Admin.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Doctorskin.Areas.Admin.Controllers
{
    public class RoleController : BaseController<RoleController>
    {
        public RoleController(ILogger<RoleController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {

        }

        public IActionResult Index(int Id)
        {
            var groupRole = _base.roleGroups.Read(x => x.Id == Id);
            ViewBag.RoleName = (groupRole != null ? groupRole.Name : string.Empty);
            List<Doctors.Base.Models.Role> model = _base.roles.GetRoleListAllByRoleGroupId(Id);
            return View(model);
        }
        public JsonResult UpdateRoleModule(List<Doctors.Base.Models.Role> lstRole)
        {
            try
            {
                if (lstRole == null || lstRole.Count < 0)
                {
                    return Error("Cập nhập không thành công!");
                }
                foreach (var item in lstRole)
                {
                    if (item.Id == 0)
                    {
                        _base.roles.Insert(item);
                    }
                    else
                    {
                        var entity = _base.roles.GetByID(item.Id);
                        if (entity != null)
                        {
                            entity.Add = item.Add;
                            entity.Edit = item.Edit;
                            entity.Delete = item.Delete;
                            entity.View = item.View;
                            entity.Confirm = item.Confirm;
                        }
                        else
                        {
                            return Error("Cập nhập không thành công!");
                        }
                        _base.roles.Update(entity);
                    }
                }
                _base.Commit();
                return Success("Cập nhật thành công!");
            }
            catch (Exception ex)
            {
                return Error("Error " + ex);
            }
        }
    }
}
