using Doctors.Base.Models;
using Doctors.Base.Session;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Reflection.Metadata.BlobBuilder;


namespace Doctors.Base.Session
{
    public class CartCookie
    {
        public static bool SetCartCookie(IHttpContextAccessor _httpContextAccessor, List<Cart> lstCart, int expireDay = 30)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(24),
                HttpOnly = false,
            };
            string cartJson = Newtonsoft.Json.JsonConvert.SerializeObject(lstCart);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("CartObj", cartJson, cookieOptions);
            return true;
        }
        public static List<Cart> GetCartCoookie(IHttpContextAccessor _httpContextAccessor)
        {
            var myCookie = _httpContextAccessor.HttpContext.Request.Cookies["CartObj"];
            if(myCookie != null)
            {
                var lstCart = JsonConvert.DeserializeObject<List<Cart>>(myCookie);
                if(lstCart != null)
                {
                    return lstCart;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public static List<CartObject> GetCartObjects(List<Cart> carts, IBase _base)
        {
            List<CartObject> cartObjects = new List<CartObject>();
            if(carts != null && carts.Count > 0)
            {
                foreach(var item in carts)
                {
                    var product = _base.products.GetByID(item.Idp);
                    if(product != null)
                    {
                        var cartobj = new CartObject
                        {
                            ProductId = item.Idp,
                            Quantity = item.Quantity,
                            ProductName = product.Namep,
                            Price = product.Newprice,
                            TotalPrice = item.Quantity * product.Newprice,
                            Images = product.Img
                        };
                        cartObjects.Add(cartobj);
                    }
                }
            }
            return cartObjects;
        }
        public static void ClearCartCookie(IHttpContextAccessor _httpContextAccessor)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("CartObj");
        }
    }
}
