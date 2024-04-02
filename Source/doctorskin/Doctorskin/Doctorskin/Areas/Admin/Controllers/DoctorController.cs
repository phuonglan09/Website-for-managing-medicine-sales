using Doctors.Base;
using Doctors.Base.Models;
using Doctorskin.Areas.Admin.Controllers.Base;
using Doctorskin.Areas.Admin.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Doctorskin.Areas.Admin.Controllers
{
    public class DoctorController : BaseController<DoctorController>
    {
        public DoctorController(ILogger<DoctorController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {

        }
        [UserAuthorize(new ActionModule[] { ActionModule.Doctor }, new ActionTypeCustom[] { ActionTypeCustom.View })]
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetDoctorData(string search, int offset, int limit)
        {
            int total = 0;
            var data = _base.doctors.GetDoctorListAllPaging(search, offset, limit);
            if (data != null && data.Count > 0)
            {
                total = data[0].TotalRow;
            }
            return Data(new { rows = data, total = total });
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Categories }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeIsHide(int Id)
        {
            try
            {
                var entity = _base.doctors.GetByID(Id);
                if (entity == null)
                {
                    return Error("Thông tin bác sĩ không tồn tại");
                }
                entity.HideDoc = (entity.HideDoc ? false : true);
                _base.doctors.Update(entity);
                _base.Commit();
                return Success("Thay đổi trạng thái thành công");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Categories }, new ActionTypeCustom[] { ActionTypeCustom.Add, ActionTypeCustom.Edit })]
        [HttpPost]
        public JsonResult CreateOrEdit(Doctor model, IFormFile fileUpload)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Namedoc))
                {
                    return Error("Vui lòng nhập tên bác sĩ");
                }
                if (string.IsNullOrEmpty(model.Infordoc))
                {
                    return Error("Vui lòng nhập thông tin bác sĩ");
                }
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
                    string SavePath = Path.Combine("wwwroot/Uploads/Doctor", newPath, filename);
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
                if (model.Id == 0)
                {
                    model.AvaDoc = pathDb;
                    model.DateUpDoc = DateTime.Now;
                    _base.doctors.Insert(model);
                }
                else
                {
                    var entity = _base.doctors.GetByID(model.Id);
                    if (entity != null)
                    {
                        entity.Namedoc = model.Namedoc;
                        entity.AvaDoc = (!string.IsNullOrEmpty(pathDb) ? pathDb : entity.AvaDoc);
                        entity.Infordoc = model.Infordoc;
                      
                        _base.doctors.Update(entity);
                    }
                    else
                    {
                        return Error("Thông tin bác sĩ không tồn tại");
                    }
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
