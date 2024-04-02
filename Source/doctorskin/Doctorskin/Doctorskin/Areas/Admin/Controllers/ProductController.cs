using Doctors.Base;
using Doctors.Base.Models;
using Doctorskin.Areas.Admin.Controllers.Base;
using Doctorskin.Areas.Admin.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Doctorskin.Areas.Admin.Controllers
{
    public class ProductController : BaseController<ProductController>
    {
        public ProductController(ILogger<ProductController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {

        }
        [UserAuthorize(new ActionModule[] { ActionModule.Product }, new ActionTypeCustom[] { ActionTypeCustom.View })]
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetProductData(string search, int offset, int limit)
        {
            int total = 0;
            var data = _base.products.GetProductListAll(search, offset, limit);
            if(data != null && data.Count > 0)
            {
                total = data[0].TotalRow;
            }
            return Data(new { rows = data, total = total });
        }
        [UserAuthorize(new ActionModule[] { ActionModule.Product }, new ActionTypeCustom[] { ActionTypeCustom.Add, ActionTypeCustom.Edit })]
        [HttpGet]
        public IActionResult CreateOrEdit(int Id)
        {
            ViewBag.ListCate = _base.categories.Get(x => x.Hide == false).ToList();
            ViewBag.ListBrand = _base.brands.Get(x => x.Hidebrand == false).ToList();
            var model = new Product();
            var detail = _base.products.GetByID(Id);
            if (detail!= null)
            {
                model = detail;
            }
            return View(model);
        }
        [HttpPost]
        public JsonResult CreateOrEdit(Product product, IFormFile fileUpload)
        {
            try
            {
                if (string.IsNullOrEmpty(product.Namep))
                {
                    return Error("Vui lòng nhập tên sản phẩm");
                }
                if (product.CateId == 0)
                {
                    return Error("Vui lòng chọn loại sản phẩm");
                }
                if(product.Newprice < 0 || product.Oldprice < 0)
                {
                    return Error("Vui lòng nhập giá sản phẩm lớn hơn 0");
                }
                if(product.Idbrand == 0)
                {
                    return Error("Vui lòng chọn nhãn hàng");
                }
                if (string.IsNullOrEmpty(product.Statep))
                {
                    return Error("Vui lòng chọn nhóm sản phẩm");
                }
                if (string.IsNullOrEmpty(product.Avilability))
                {
                    return Error("Vui lòng chọn tình trạng");
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
                    string SavePath = Path.Combine("wwwroot/Uploads/Product", newPath, filename);
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
                if (product.Id == 0)
                {
                    product.Img = pathDb;
                    product.DateUp = DateTime.Now;
                    _base.products.Insert(product);
                }
                else
                {
                    var entity = _base.products.GetByID(product.Id);
                    if (entity != null)
                    {
                        entity.Namep = product.Namep;
                        entity.Img = (!string.IsNullOrEmpty(pathDb) ? pathDb : entity.Img);
                        entity.Newprice = product.Newprice;
                        entity.Descr = product.Descr;
                        entity.Oldprice = product.Oldprice;
                        entity.Hide = product.Hide;
                        entity.Statep = product.Statep;
                        entity.CateId = product.CateId;
                        entity.Idbrand = product.Idbrand;
                        entity.Avilability = product.Avilability;
                        _base.products.Update(entity);
                    }
                    else
                    {
                        return Error("Thông tin sản phẩm không tồn tại");
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
        [UserAuthorize(new ActionModule[] { ActionModule.Product }, new ActionTypeCustom[] { ActionTypeCustom.Confirm })]
        public JsonResult ChangeIsHide(int Id)
        {
            try
            {
                var entity = _base.products.GetByID(Id);
                if (entity == null)
                {
                    return Error("Thông tin sản phẩm không tồn tại");
                }
                entity.Hide = (entity.Hide ? false : true);
                _base.products.Update(entity);
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
