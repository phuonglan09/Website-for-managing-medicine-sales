using Doctors.Base;
using Doctors.Base.Models;
using Doctorskin.Areas.Admin.Controllers.Base;
using Doctorskin.Areas.Admin.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Areas.Admin.Controllers
{
    public class CategoriesController : BaseController<CategoriesController>
    {
        public CategoriesController(ILogger<CategoriesController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {

        }
        [UserAuthorize(new ActionModule[] { ActionModule.Categories }, new ActionTypeCustom[] { ActionTypeCustom.View })]
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetCategoriesData(string search, int offset, int limit)
        {
            int total = 0;
            var data = _base.categories.GetCategoriesListAll(search, offset, limit);
            if(data != null && data.Count > 0)
            {
                total = data[0].TotalRow;
            }
            return Data(new { rows = data, total = total });
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Categories }, new ActionTypeCustom[] { ActionTypeCustom.Add, ActionTypeCustom.Edit })]
        public JsonResult CreateOrEdit(Category model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Namec))
                {
                    return Error("Vui lòng nhập loại sản phẩm");
                }
                var ckName = _base.categories.Read(x => x.Namec.Equals(model.Namec.Trim()) && x.Id != model.Id);
                if(ckName != null)
                {
                    return Error("Tên loại sản phẩm đã tồn tại");
                }
                if(model.Id == 0)
                {
                    model.Hide = false;
                    model.DateUp = DateTime.Now;
                    _base.categories.Insert(model);
                }
                else
                {
                    var entity = _base.categories.GetByID(model.Id);
                    if(entity == null)
                    {
                        return Error("Thông tin loại sản phẩm không tồn tại");
                    }
                    entity.Namec = model.Namec;
                    _base.categories.Update(entity);
                }
                _base.Commit();
                return Success("Cập nhật thông tin thành công");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Categories }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeIsHide(int Id)
        {
            try
            {
                var entity = _base.categories.GetByID(Id);
                if (entity == null)
                {
                    return Error("Thông tin loại sản phẩm không tồn tại");
                }
                entity.Hide = (entity.Hide ? false : true);
                _base.categories.Update(entity);
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
