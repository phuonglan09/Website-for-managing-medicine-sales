using Doctors.Base;
using Doctors.Base.Models;
using Doctors.Base.Session;
using Doctorskin.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Doctorskin.Controllers
{
    public class CheckOutController : BaseAuthController<CheckOutController>
    {
        private readonly IBase _base;
        public CheckOutController(ILogger<CheckOutController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {
            _logger = logger;
            _base = @base;
        }
        public IActionResult Index()
        {
            decimal totalPrice = 0;
            List<CartObject> model = new List<CartObject>();
            User users = new User();
            if(GetUser() != null)
            {
                users = _base.users.GetByID(GetUser().CustomerId);
            }
            ViewBag.Users = users;
            var cookie = CartCookie.GetCartCoookie(_contextAccessor);
            var cartObj = CartCookie.GetCartObjects(cookie, _base);
            if (cartObj != null && cartObj.Count > 0)
            {
                model = cartObj.OrderByDescending(x => x.ProductId).ToList();
                totalPrice = model.Sum(x => x.TotalPrice);
            }
            ViewBag.TotalPriceAll = totalPrice;
            return View(model);
        }
        public JsonResult PaymentCheckOut(string phone, string address)
        {
            try
            {
                var user = GetUser();
                if(user == null)
                {
                    return Error("Vui lòng đăng nhập để thanh toán ");
                }
                if (string.IsNullOrEmpty(phone))
                {
                    return Error("Vui lòng nhập số điện thoại");
                }
                if (string.IsNullOrEmpty(address))
                {
                    return Error("Vui lòng nhập địa chỉ giao hàng");
                }
                var cookie = CartCookie.GetCartCoookie(_contextAccessor);
                if(cookie == null)
                {
                    return Error("Hết phiên lưu thông tin sản phẩm trong giỏ hàng");
                }
                var cartObj = CartCookie.GetCartObjects(cookie, _base);
                if(cartObj != null && cartObj.Count > 0)
                {
                    foreach (var cart in cookie)
                    {
                        var cartModel = new Cart
                        {
                            Iduser = user.CustomerId,
                            Idp = cart.Idp,
                            Quantity = cart.Quantity
                        };
                        _base.carts.Insert(cartModel);
                    }
                    decimal totalPriceAll = cartObj.Sum(x => x.TotalPrice);
                    var orderCode = DateTime.Now.ToString("yyMMddhhmmssfff");
                    var orderModel = new Order
                    {
                        OrderCode = orderCode,
                        UserId = user.CustomerId,
                        TotalAmount = totalPriceAll,
                        Status = 1,
                        PhoneAddress = phone,
                        Address = address,
                    };
                    int orderId = _base.orders.InserOrder(orderModel);
                    if(orderId == 0)
                    {
                        return Error("Có lỗi xảy ra, không thể đặt hàng được");
                    }
                    foreach(var item1 in cartObj)
                    {
                        var orderDetail = new OrderDetail
                        {
                            OrderId = orderId,  
                            ProductId = item1.ProductId,
                            UnitPrice = item1.Price,
                            Quantity = item1.Quantity,
                        };
                        _base.orderDetails.Insert(orderDetail);
                    }
                    _base.Commit();
                    CartCookie.ClearCartCookie(_contextAccessor);
                    return Success("Đặt hàng thành công");
                }
                else
                {
                    return Error("Hết phiên lưu thông tin sản phẩm trong giỏ hàng");
                }
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
    }
}
