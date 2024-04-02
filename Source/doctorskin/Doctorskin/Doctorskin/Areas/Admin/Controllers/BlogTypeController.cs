using Doctors.Base;
using Doctors.Base.Models;
using Doctorskin.Areas.Admin.Controllers.Base;
using Doctorskin.Areas.Admin.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.RegularExpressions;

namespace Doctorskin.Areas.Admin.Controllers
{
    public class BlogTypeController : BaseController<BlogTypeController>
    {
        public BlogTypeController(ILogger<BlogTypeController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {

        }
        [UserAuthorize(new ActionModule[] { ActionModule.Blog }, new ActionTypeCustom[] { ActionTypeCustom.View })]
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetDataBlogType(string search)
        {
            var data =  _base.blogTypes.Get().ToList();
            int total = data.Count;
            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(x => x.Namebt.Contains(search)).ToList();
            }
            return Data(new { rows = data, total = total });
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Blog }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeIsHide(int Id)
        {
            try
            {
                var entity = _base.blogTypes.GetByID(Id);
                if (entity == null)
                {
                    return Error("Thông tin loại bài viết không tồn tại");
                }
                entity.Hide = (entity.Hide ? false : true);
                _base.blogTypes.Update(entity);
                _base.Commit();
                return Success("Thay đổi trạng thái thành công");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Blog }, new ActionTypeCustom[] { ActionTypeCustom.Add, ActionTypeCustom.Edit })]
        public JsonResult CreateOrEdit(BlogType model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Namebt))
                {
                    return Error("Vui lòng nhập loại bài viết");
                }
                var ckName = _base.blogTypes.Read(x => x.Namebt.Equals(model.Namebt.Trim()) && x.Id != model.Id);
                if (ckName != null)
                {
                    return Error("Loại bài viết đã tồn tại");
                }
                if (model.Id == 0)
                {
                    model.Hide = false;
                    _base.blogTypes.Insert(model);
                }
                else
                {
                    var entity = _base.blogTypes.GetByID(model.Id);
                    if (entity == null)
                    {
                        return Error("Thông tin loại bài viết không tồn tại");
                    }
                    entity.Namebt = model.Namebt;
                    _base.blogTypes.Update(entity);
                }
                _base.Commit();
                return Success("Cập nhật thông tin thành công");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Blog }, new ActionTypeCustom[] { ActionTypeCustom.View })]
        public IActionResult Blog()
        {
            return View();
        }
        public JsonResult GetBlogData(string search, int offset, int limit)
        {
            int total = 0;
            var data = _base.blogDetails.GetBlogDetailListAllPaging(search, offset, limit);
            if (data != null && data.Count > 0)
            {
                total = data[0].TotalRow;
            }
            return Data(new { rows = data, total = total });
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Blog }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeIsHideBlog(int Id)
        {
            try
            {
                var entity = _base.blogDetails.GetByID(Id);
                if (entity == null)
                {
                    return Error("Thông tin bài viết không tồn tại");
                }
                entity.Hideblog = (entity.Hideblog ? false : true);
                _base.blogDetails.Update(entity);
                _base.Commit();
                return Success("Thay đổi trạng thái thành công");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Blog }, new ActionTypeCustom[] { ActionTypeCustom.Add, ActionTypeCustom.Edit })]
        [HttpGet]
        public IActionResult CreateOrEditBlog(int Id)
        {
            ViewBag.ListBlogType = _base.blogTypes.Get(x => x.Hide == false).ToList();
            var model = new BlogDetail();
            var entity = _base.blogDetails.GetByID(Id);
            if(entity != null)
            {
                model = entity;
            }
            return View(model);
        }
        [HttpPost]
        public JsonResult CreateOrEditBlog(BlogDetail model, IFormFile fileUpload)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Title))
                {
                    return Error("Vui lòng nhập tiêu đề");
                }
                if (model.BlogTypeId == 0)
                {
                    return Error("Vui lòng chọn loại bài viết");
                }
                if (string.IsNullOrEmpty(model.Shortcontent))
                {
                    return Error("Vui lòng nhập mô tả ngắn");
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
                    string SavePath = Path.Combine("wwwroot/Uploads/Blogs", newPath, filename);
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
                    model.Cardimg = pathDb;
                    model.DateUp = DateTime.Now;
                    _base.blogDetails.Insert(model);
                }
                else
                {
                    var entity = _base.blogDetails.GetByID(model.Id);
                    if (entity != null)
                    {
                        entity.Title = model.Title;
                        entity.Cardimg = (!string.IsNullOrEmpty(pathDb) ? pathDb : entity.Cardimg);
                        entity.Shortcontent = model.Shortcontent;
                        entity.BlogTypeId = model.BlogTypeId;
                        entity.Contentblog = model.Contentblog;
                        _base.blogDetails.Update(entity);
                    }
                    else
                    {
                        return Error("Thông tin bài viết không tồn tại");
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
