using Doctors.Base;
using Doctors.Base.Models;
using Doctorskin.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Controllers
{
    public class BlogController : BaseAuthController<BlogController>
    {
        private readonly IBase _base;
        public BlogController(ILogger<BlogController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {
            _logger = logger;
            _base = @base;
        }
        public IActionResult Index(int? page)
        {
            ViewDefault();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            int startIndex = (pageNumber - 1) * pageSize;
            List<BlogDetail> lstBlog = _base.blogDetails.Get(x => x.Hideblog == false).ToList();
            List<BlogDetail> model = lstBlog.Take(pageSize).Skip(startIndex).ToList();
            // Truyền dữ liệu phân trang vào view
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling((double)lstBlog.Count / pageSize);
            return View(model);
        }
        public IActionResult Detail(int Id)
        {
            ViewDefault();
            List<BlogDetail> lstBlogByType = new List<BlogDetail>();
            BlogDetail model = _base.blogDetails.GetByID(Id);
            if(model != null)
            {
                lstBlogByType = _base.blogDetails.Get(x => x.BlogTypeId == model.BlogTypeId).Take(2).ToList();
            }
            ViewBag.ListBlofByType = lstBlogByType;
            return View(model);
        }
        public void ViewDefault()
        {
            ViewBag.Banner = _base.banners.Get(x => x.Blogpage == true).OrderByDescending(x => x.Id).FirstOrDefault();
        }
    }
}
