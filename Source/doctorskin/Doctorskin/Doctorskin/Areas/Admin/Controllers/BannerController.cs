using Doctors.Base;
using Doctors.Base.Models;
using Doctorskin.Areas.Admin.Controllers.Base;
using Doctorskin.Areas.Admin.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Doctorskin.Areas.Admin.Controllers
{
    public class BannerController : BaseController<BannerController>
    {
        public BannerController(ILogger<BannerController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {

        }
        [UserAuthorize(new ActionModule[] { ActionModule.Banner }, new ActionTypeCustom[] { ActionTypeCustom.View })]
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetBannerData()
        {
            var data = _base.banners.Get().ToList();
            int total = data.Count();
            return Data(new { rows = data, total = total });
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Banner }, new ActionTypeCustom[] { ActionTypeCustom.Delete })]
        public JsonResult Delete(int Id)
        {
            try
            {
                var entity = _base.banners.GetByID(Id);
                if(entity == null)
                {
                    return Error("Thông tin banner không tồn tại");
                }
                _base.banners.Delete(entity);
                _base.Commit();
                return Success("Xóa thông tin thành công!");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Banner }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeIsHome(int Id)
        {
            try
            {
                var entity = _base.banners.GetByID(Id);
                if (entity == null)
                {
                    return Error("Thông tin banner không tồn tại");
                }
                entity.Homepage = (entity.Homepage ? false : true);
                _base.banners.Update(entity);
                _base.Commit();
                return Success("Thay đổi trạng thái thành công!");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Banner }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeIsServicepage(int Id)
        {
            try
            {
                var entity = _base.banners.GetByID(Id);
                if (entity == null)
                {
                    return Error("Thông tin banner không tồn tại");
                }
                entity.Servicepage = (entity.Servicepage ? false : true);
                _base.banners.Update(entity);
                _base.Commit();
                return Success("Thay đổi trạng thái thành công!");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Banner }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeIsBlogpage(int Id)
        {
            try
            {
                var entity = _base.banners.GetByID(Id);
                if (entity == null)
                {
                    return Error("Thông tin banner không tồn tại");
                }
                entity.Blogpage = (entity.Blogpage ? false : true);
                _base.banners.Update(entity);
                _base.Commit();
                return Success("Thay đổi trạng thái thành công!");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Banner }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeIsProductpage(int Id)
        {
            try
            {
                var entity = _base.banners.GetByID(Id);
                if (entity == null)
                {
                    return Error("Thông tin banner không tồn tại");
                }
                entity.Productpage = (entity.Productpage ? false : true);
                _base.banners.Update(entity);
                _base.Commit();
                return Success("Thay đổi trạng thái thành công!");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Banner }, new ActionTypeCustom[] { ActionTypeCustom.Add })]
        [HttpPost]
        public JsonResult CreateOrEdit(IFormFile fileUpload)
        {
            try
            {
                var model = new Banner();
                var pathDb = string.Empty;
                if (fileUpload != null)
                {
                    Regex rgx = new Regex(@"(.*?)\.(jpg|bmp|png|gif|jfif|JPG|PNG|BMP|GIF|JFIF)$");
                    if (!rgx.IsMatch(fileUpload.FileName))
                    {
                        return Error("Định dạnh ảnh không hợp lệ");
                    }
                    string filename = DateTime.Now.ToString("yyyyMMdd") + '_' + fileUpload.FileName;
                    string folderName = DateTime.Now.ToString("yyMMdd");
                    string newPath = Path.Combine(folderName);
                    string SavePath = Path.Combine("wwwroot/Uploads/Banner", newPath, filename);
                    var fi = new FileInfo(SavePath);
                    if (!Directory.Exists(fi.DirectoryName))
                    {
                        Directory.CreateDirectory(fi.DirectoryName);
                    }
                    using (var stream = new FileStream(SavePath, FileMode.Create))
                    {
                        fileUpload.CopyTo(stream);
                    }
                    pathDb = folderName + "\\" + filename;
                }
                else
                {
                    return Error("Vui lòng nhập ảnh banner");
                }
                if (model.Id == 0)
                {
                    model.Image = pathDb;
                    _base.banners.Insert(model);
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
