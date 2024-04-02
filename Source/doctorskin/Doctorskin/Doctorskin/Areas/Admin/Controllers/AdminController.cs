﻿using Doctors.Base;
using Doctors.Base.Extension;
using Doctorskin.Areas.Admin.Controllers.Base;
using Doctorskin.Areas.Admin.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Areas.Admin.Controllers
{
    public class AdminController : BaseController<AdminController>
    {
        public AdminController(ILogger<AdminController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {

        }
        [UserAuthorize(new ActionModule[] { ActionModule.Admin }, new ActionTypeCustom[] { ActionTypeCustom.View })]
        public IActionResult Index()
        {
            ViewBag.ListRoleGroup = _base.roleGroups.Get();
            return View();
        }
        public JsonResult GetAdminData(string search, int offset, int limit)
        {
            int total = 0;
            var data = _base.admins.GetAdminListAll(search, offset, limit);
            if (data != null && data.Count > 0)
            {
                total = data[0].TotalRow;
            }
            return Data(new { rows = data, total = total });
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Admin }, new ActionTypeCustom[] { ActionTypeCustom.Add, ActionTypeCustom.Edit })]
        public JsonResult CreateOrEdit(Doctors.Base.Models.Admin admin)
        {
            try
            {
                if (string.IsNullOrEmpty(admin.FullName) || string.IsNullOrEmpty(admin.Address) || string.IsNullOrEmpty(admin.Phone) || admin.RoleGroupId == 0 || string.IsNullOrEmpty(admin.Username) || (admin.Id == 0 && string.IsNullOrEmpty(admin.Password)))
                {
                    return Error("Vui lòng nhập đầy đủ thông tin");
                }
                var ckUsername = _base.admins.Read(x => x.Username.Equals(admin.Username.Trim()) && x.Id != admin.Id);
                if(ckUsername != null)
                {
                    return Error("Thông tin tài khoản đã tồn tại");
                }
                if(admin.Id == 0)
                {
                    var passHash = Hash.sha256(admin.Password);
                    admin.Password = passHash;
                    admin.IsActive = true;
                    _base.admins.Insert(admin);
                }
                else
                {
                    var entity = _base.admins.GetByID(admin.Id);
                    if(entity == null)
                    {
                        return Error("Cập nhật thông tin không thành công");
                    }
                    entity.FullName = admin.FullName;
                    entity.Address = admin.Address;
                    entity.Phone = admin.Phone;
                    entity.Password = (!string.IsNullOrEmpty(admin.Password) ? Hash.sha256(admin.Password) : entity.Password);
                    _base.admins.Update(entity);
                }
                _base.Commit();
                return Success("Cập nhật thông tin thành công");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Admin }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeIsActive(int Id)
        {
            try
            {
                var entity = _base.admins.GetByID(Id);
                if (entity == null)
                {
                    return Error("Thông tin nhân viên không tồn tại");
                }
                entity.IsActive = (entity.IsActive ? false : true);
                _base.admins.Update(entity);
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
