using Doctors.Base;
using Doctors.Base.Models;
using Doctorskin.Areas.Admin.Controllers.Base;
using Doctorskin.Areas.Admin.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Areas.Admin.Controllers
{
    public class BrandController : BaseController<BrandController>
    {
        public BrandController(ILogger<BrandController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {

        }
        [UserAuthorize(new ActionModule[] { ActionModule.Brand }, new ActionTypeCustom[] { ActionTypeCustom.View })]
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetBrandData(string search, int offset, int limit)
        {
            int total = 0;
            var data = _base.brands.GetBrandListAllPaging(search, offset, limit);
            if (data != null && data.Count > 0)
            {
                total = data[0].TotalRow;
            }
            return Data(new { rows = data, total = total });
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Brand }, new ActionTypeCustom[] { ActionTypeCustom.Add, ActionTypeCustom.Edit })]
        public JsonResult CreateOrEdit(Brand model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Namebrand))
                {
                    return Error("Vui lòng nhập tên nhãn hiệu");
                }
                var ckName = _base.brands.Read(x => x.Namebrand.Equals(model.Namebrand.Trim()) && x.Id != model.Id);
                if (ckName != null)
                {
                    return Error("Tên loại sản phẩm đã tồn tại");
                }
                if (model.Id == 0)
                {
                    model.Hidebrand = false;
                    _base.brands.Insert(model);
                }
                else
                {
                    var entity = _base.brands.GetByID(model.Id);
                    if (entity == null)
                    {
                        return Error("Thông tin nhãn hiệu không tồn tại");
                    }
                    entity.Namebrand = model.Namebrand;
                    _base.brands.Update(entity);
                }
                _base.Commit();
                return Success("Cập nhật thông tin thành công");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Brand }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeIsHide(int Id)
        {
            try
            {
                var entity = _base.brands.GetByID(Id);
                if (entity == null)
                {
                    return Error("Thông tin nhãn hiệu không tồn tại");
                }
                entity.Hidebrand = (entity.Hidebrand ? false : true);
                _base.brands.Update(entity);
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
