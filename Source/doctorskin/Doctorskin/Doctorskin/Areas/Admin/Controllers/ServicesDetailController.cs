using Doctors.Base;
using Doctors.Base.Models;
using Doctorskin.Areas.Admin.Controllers.Base;
using Doctorskin.Areas.Admin.Helper;
using Doctorskin.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Doctorskin.Areas.Admin.Controllers
{
    public class ServicesDetailController : BaseController<ServicesDetailController>
    {
        public ServicesDetailController(ILogger<ServicesDetailController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {

        }
        [UserAuthorize(new ActionModule[] { ActionModule.ServicesDetail }, new ActionTypeCustom[] { ActionTypeCustom.View })]
        public IActionResult Index(int id)
        {
            return View();
        }
        public JsonResult GetServiceData(string search, int offset, int limit)
        {
            int total = 0;
            var data = _base.services.GetServicesListAllPaging(search, offset, limit);
            if(data != null && data.Count > 0)
            {
                total = data[0].TotalRow;
            }
            return Data(new { rows = data, total = total });
        }
        [UserAuthorize(new ActionModule[] { ActionModule.ServicesDetail }, new ActionTypeCustom[] { ActionTypeCustom.Add, ActionTypeCustom.Edit })]
        public JsonResult CreateOrEdit(Service service, IFormFile fileUpload)
        {
            try
            {
                string pathDb = string.Empty;
                if (fileUpload != null)
                {
                    Regex rgx = new Regex(@"(.*?)\.(jfif|jpg|tiff|jpeg|nef|ai|bmp|png|gif|JPG|PNG|BMP|GIF|TIFF|NEF|AI|JPEG)$");
                    if (!rgx.IsMatch(fileUpload.FileName))
                    {
                        return Error("Định dạng ảnh không hợp lệ");
                    }
                    var fileName = DateTime.Now.ToString("yyyyMMdd") + "_" + fileUpload.FileName;
                    string folderName = DateTime.Now.ToString("yyMMdd");
                    string newPath = Path.Combine(folderName);
                    string savePath = Path.Combine("wwwroot/Uploads/Service", newPath, fileName);
                    var fi = new FileInfo(savePath);
                    if (!Directory.Exists(fi.DirectoryName))
                    {
                        Directory.CreateDirectory(fi.DirectoryName);
                    }
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        fileUpload.CopyTo(stream);
                    }
                    pathDb = folderName + "\\" + fileName;
                }
                if (string.IsNullOrEmpty(service.NameDt))
                {
                    return Error("Vui lòng nhập tên dịch vụ");
                }
                var ckName = _base.services.Read(x => x.NameDt.Equals(service.NameDt.Trim()) && x.Id != service.Id);
                if(ckName != null)
                {
                    return Error("Tên dịch vụ đã tồn tại");
                }
                if (service.Id == 0)
                {
                    service.ImgDt = pathDb;
                    service.HideDt = false;
                    _base.services.Insert(service);
                }
                else
                {
                    var entity = _base.services.GetByID(service.Id);
                    if (entity == null)
                    {
                        return Error("Thông tin dịch vụ không tồn tại");
                    }
                    entity.NameDt = service.NameDt;
                    entity.DescDt = service.DescDt;
                    entity.ImgDt = (!string.IsNullOrEmpty(pathDb) ? pathDb : entity.ImgDt);
                    _base.services.Update(entity);
                }
                _base.Commit();
                return Success("Cập nhật thông tin thành công ");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.ServicesDetail }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeIsActive(int Id)
        {
            try
            {
                var entity = _base.services.GetByID(Id);
                if(entity == null)
                {
                    return Error("Thông tin dịch vụ không tồn tại");
                }
                entity.HideDt = (entity.HideDt ? false : true);
                _base.services.Update(entity);
                _base.Commit();
                return Success("Thay đổi trạng thái thành công");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.ServicesDetail }, new ActionTypeCustom[] { ActionTypeCustom.View })]
        public IActionResult ServiceDetail(int Id)
        {
            Service model = _base.services.GetByID(Id);
            return View(model);
        }
        public JsonResult GetServiceDetailData(int serviceId, string search, int offset, int limit)
        {
            int total = 0;
            var data = _base.serviceDetail.GetServiceDetailListAll(serviceId, search, offset, limit);
            if(data != null && data.Count > 0)
            {
                total = data[0].TotalRow;
            }
            return Data(new { rows = data, total = total });
        }
        [UserAuthorize(new ActionModule[] { ActionModule.ServicesDetail }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeIsHidenSd(int Id)
        {
            try
            {
                var entity = _base.serviceDetail.GetByID(Id);
                if (entity == null)
                {
                    return Error("Thông tin dịch vụ không tồn tại");
                }
                entity.HideSd = (entity.HideSd ? false : true);
                _base.serviceDetail.Update(entity);
                _base.Commit();
                return Success("Thay đổi trạng thái thành công");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.ServicesDetail }, new ActionTypeCustom[] { ActionTypeCustom.Add, ActionTypeCustom.Edit })]
        public JsonResult CreateOrEditDetail(ServicesDetail detail, IFormFile fileUpload)
        {
            try
            {
                string pathDb = string.Empty;
                if (fileUpload != null)
                {
                    Regex rgx = new Regex(@"(.*?)\.(jfif|jpg|tiff|jpeg|nef|ai|bmp|png|gif|JPG|PNG|BMP|GIF|TIFF|NEF|AI|JPEG)$");
                    if (!rgx.IsMatch(fileUpload.FileName))
                    {
                        return Error("Định dạng ảnh không hợp lệ");
                    }
                    var fileName = DateTime.Now.ToString("yyyyMMdd") + "_" + fileUpload.FileName;
                    string folderName = DateTime.Now.ToString("yyMMdd");
                    string newPath = Path.Combine(folderName);
                    string savePath = Path.Combine("wwwroot/Uploads/Service", newPath, fileName);
                    var fi = new FileInfo(savePath);
                    if (!Directory.Exists(fi.DirectoryName))
                    {
                        Directory.CreateDirectory(fi.DirectoryName);
                    }
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        fileUpload.CopyTo(stream);
                    }
                    pathDb = folderName + "\\" + fileName;
                }
                if (string.IsNullOrEmpty(detail.NameSd))
                {
                    return Error("Vui lòng nhập tên dịch vụ");
                }
                var ckName = _base.serviceDetail.Read(x => x.NameSd.Equals(detail.NameSd.Trim()) && x.Id != detail.Id);
                if (ckName != null)
                {
                    return Error("Tên dịch vụ đã tồn tại");
                }
                if (detail.Id == 0)
                {
                    detail.ImgSd = pathDb;
                    detail.HideSd = false;
                    _base.serviceDetail.Insert(detail);
                }
                else
                {
                    var entity = _base.serviceDetail.GetByID(detail.Id);
                    if (entity == null)
                    {
                        return Error("Thông tin dịch vụ không tồn tại");
                    }
                    entity.NameSd = detail.NameSd;
                    entity.PriceSd = detail.PriceSd;
                    entity.Amount = detail.Amount;
                    entity.DescDe = detail.DescDe;
                    entity.ImgSd = (!string.IsNullOrEmpty(pathDb) ? pathDb : entity.ImgSd);
                    _base.serviceDetail.Update(entity);
                }
                _base.Commit();
                return Success("Cập nhật thông tin thành công ");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
    }
}
