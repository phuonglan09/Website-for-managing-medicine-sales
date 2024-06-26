﻿using Doctors.Base;
using Doctors.Base.Extension;
using Doctors.Base.Models;
using Doctorskin.Controllers.Base;
using Doctorskin.Models;
using Doctors.Base.Session;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Tls;
using OtpNet;
using System.Net.Mail;
using System.Text;

namespace Doctorskin.Controllers
{
    public class LoginController : BaseAuthController<LoginController>
    {
        private readonly IBase _base;
        public LoginController(ILogger<LoginController> logger, IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IBase @base) : base(@base, httpContextAccessor, configuration, logger)
        {
            _base = @base;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult Login(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    return Error("Vui lòng nhập email và mật khẩu");
                }
                var pashHash = Hash.sha256(password.Trim());
                var data = _base.users.Read(x => x.Email.Equals(username.Trim()) && x.Password.Equals(pashHash) && x.Hide == false);
                if (data == null)
                {
                    return Error("Thông tin tài khoản hoặc mật khẩu không chính xác");
                }
                SetUser(new CustomerSession
                {
                    CustomerId = data.Id,
                    Username = data.Email,
                    FullName = data.Name
                });
                return Success("Đăng nhập thành công");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public JsonResult Register(RegisterModel model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password) || string.IsNullOrEmpty(model.Confirmpassword))
                {
                    return Error("Vui lòng nhập đầy đủ thông tin");
                }
                if (!model.Password.Trim().Equals(model.Confirmpassword.Trim()))
                {
                    return Error("Mật khẩu xác nhận không trùng mới mật khẩu mới");
                }
                var ckEmail = _base.users.Read(x => x.Email.Trim().Equals(model.Email.Trim()));
                if (ckEmail != null)
                {
                    return Error("Thông tin email và tài khoản đã tồn tại");
                }
                var codeOTP = CreateOTP(model.Email.Trim());
                if (string.IsNullOrEmpty(codeOTP))
                {
                    return Error("Không tạo được mã OTP. Vui lòng liên hệ với quản trị viên");
                }
                bool flag = SendMail(model.Email, codeOTP);
                if (!flag)
                {
                    return Error("Không gửi được mail xác thực otp. Vui lòng liên hệ quản trị viên");
                }
                var hashPass = Hash.sha256(model.Password);
                var user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = hashPass,
                    Hide = true,
                    Dateregist = DateTime.Now
                };
                _base.users.Insert(user);
                _base.Commit();
                return Data(new { status = true, message = "Đăng ký tài khoản thành công. Vui lòng nhập mã OTP để xác thực tài khoản", email = model.Email });
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        public string CreateOTP(string email)
        {
            Totp totp = new Totp(Encoding.ASCII.GetBytes(email), 120, OtpHashMode.Sha256, 8);
            var otp = totp.ComputeTotp();
            return otp;
        }
        public bool ValidateOTP(string otp, string email)
        {
            Totp totp = new Totp(Encoding.ASCII.GetBytes(email), 120, OtpHashMode.Sha256, 8);
            long time = 0;
            var flag = totp.VerifyTotp(otp, out time);
            return flag;
        }
        public bool SendMail(string emailTo, string otpcode)
        {
            try
            {
                var servername = _configuration.GetSection("servername");
                var emailaddress = _configuration.GetSection("email");
                var port = _configuration.GetSection("port");
                var password = _configuration.GetSection("password");
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(servername.Value);
                mail.From = new MailAddress(emailaddress.Value);
                mail.IsBodyHtml = true;
                mail.To.Add(emailTo);
                mail.Subject = "Xác nhận mã OTP";
                mail.Body = "<p style='text-align: left;'>Bạn đang thực hiện xác thực tài khoản</p> " +
                            "<p style='text-align:left;'>Nhập OTP: " + otpcode + " để xác thực tài khoản đăng ký." +
                            "OTP có hiệu lực trong 2 phút. Không cung cấp OTP cho bất kì ai.</p>";
                SmtpServer.Port = int.Parse(port.Value);
                SmtpServer.Credentials = new System.Net.NetworkCredential(emailaddress.Value, password.Value);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SendMailForgot(string emailTo, string otpcode)
        {
            try
            {
                var servername = _configuration.GetSection("servername");
                var emailaddress = _configuration.GetSection("email");
                var port = _configuration.GetSection("port");
                var password = _configuration.GetSection("password");
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(servername.Value);
                mail.From = new MailAddress(emailaddress.Value);
                mail.IsBodyHtml = true;
                mail.To.Add(emailTo);
                mail.Subject = "Xác nhận mã OTP";
                mail.Body = "<p style='text-align: left;'>Bạn đang thực hiện lấy lại mật khẩu</p> " +
                            "<p style='text-align:left;'>Nhập OTP: " + otpcode + " để xác thực tài khoản." +
                            "OTP có hiệu lực trong 2 phút. Không cung cấp OTP cho bất kì ai.</p>";
                SmtpServer.Port = int.Parse(port.Value);
                SmtpServer.Credentials = new System.Net.NetworkCredential(emailaddress.Value, password.Value);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        [HttpGet]
        public IActionResult ConfirmRegisterOTP(string email)
        {
            ViewBag.Email = email;
            return View();
        }
        [HttpPost]
        public JsonResult ConfirmRegisterOTP(string email, string otpCode)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return Error("Không tìm thấy email xác thực");
                }
                if (string.IsNullOrEmpty(otpCode))
                {
                    return Error("Vui lòng nhập mã OTP");
                }
                var ckEmail = _base.users.Read(x => x.Email.ToLower().Trim().Equals(email.ToLower().Trim()));
                if(ckEmail == null)
                {
                    return Error("Không tìm thấy email xác thực");
                }
                bool flag = ValidateOTP(otpCode, email);
                if (!flag)
                {
                    return Error("Mã OTP không chính xác hoặc đã hết hạn. Vui lòng thử lại");
                }
                ckEmail.Hide = false;
                _base.users.Update(ckEmail);
                _base.Commit();
                return Success("Xác nhận tài khoản thành công!");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        public IActionResult Logout()
        {
            ClearUser();
            return Redirect("/Login/Index");
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ForgotPassword(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return Error("Vui lòng nhập email đăng ký tài khoản của bạn");
                }
                var entity = _base.users.Read(x => x.Email.ToLower().Trim().Equals(email.ToLower().Trim()) && x.Hide == false);
                if(entity == null)
                {
                    return Error("Không tìm thấy email trong hệ thống");
                }
                var codeOTP = CreateOTP(email.Trim());
                if (string.IsNullOrEmpty(codeOTP))
                {
                    return Error("Không tạo được mã OTP. Vui lòng liên hệ với quản trị viên");
                }
                bool flag = SendMailForgot(email, codeOTP);
                if (!flag)
                {
                    return Error("Không gửi được mail xác thực otp. Vui lòng liên hệ quản trị viên");
                }
                int userId = entity.Id;
                return Data(new { status = true, message = "Kiểm tra thông tin email thành công", id = userId });
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult ConfirmForgotOTP(int Id)
        {
            ViewBag.UserId = Id;
            return View();
        }
        [HttpPost]
        public JsonResult ConfirmForgotOTP(int Id, string otpCode)
        {
            try
            {
                if (string.IsNullOrEmpty(otpCode))
                {
                    return Error("Vui lòng nhập mã OTP");
                }
                var ckUser = _base.users.Read(x => x.Id == Id && x.Hide == false);
                if (ckUser == null)
                {
                    return Error("Không tìm thấy tài khoản xác thực");
                }
                bool flag = ValidateOTP(otpCode, ckUser.Email);
                if (!flag)
                {
                    return Error("Mã OTP không chính xác hoặc đã hết hạn. Vui lòng thử lại");
                }
                return Data(new {status = true, message = "Xác nhận tài khoản thành công!", id = Id});
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [HttpGet]
        public IActionResult ResetPassword (int Id)
        {
            ViewBag.UserId = Id;
            return View();
        }
        [HttpPost]
        public JsonResult ResetPassword(int Id, string newPassword, string confirmPassword)
        {
            try
            {
                var entity = _base.users.GetByID(Id);
                if(entity == null)
                {
                    return Error("Không tìm thấy thông tin tài khoản cần thay đổi");
                }
                if(string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(newPassword))
                {
                    return Error("Vui lòng nhập đầy đủ thông tin");
                }
                if (!newPassword.Trim().Equals(confirmPassword.Trim()))
                {
                    return Error("Mật khẩu xác nhận không trùng với mật khẩu mới");
                }
                var hashPass = Hash.sha256(newPassword);
                entity.Password = hashPass;
                _base.users.Update(entity);
                _base.Commit();
                return Success("Đặt lại mật khẩu thành công");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassWord(ChangePassword data)
        {
            try
            {
                var user = GetUser();
                if (user == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                var dataUser = _base.users.GetByID(user.CustomerId);
                if (dataUser == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                if (string.IsNullOrEmpty(data.OldPassword))
                {
                    return Error("Vui lòng nhập mật khẩu cũ");
                }
                if (string.IsNullOrEmpty(data.NewPassword))
                {
                    return Error("Vui lòng nhập mật khẩu mới");
                }
                if (string.IsNullOrEmpty(data.ConfirmPassword))
                {
                    return Error("Vui lòng nhập mật khẩu xác nhận");
                }
                var hashPassOld = Hash.sha256(data.OldPassword);
                if (!dataUser.Password.Equals(hashPassOld))
                {
                    return Error("Mật khẩu cũ không chính xác");
                }
                if (data.NewPassword.Equals(data.OldPassword))
                {
                    return Error("Mật khẩu mới không thể trùng với mật khẩu cũ");
                }
                if (!data.ConfirmPassword.Equals(data.NewPassword))
                {
                    return Error("Mật khẩu mới và mật khẩu xác nhận không trùng nhau");
                }
                var hashPassNew = Hash.sha256(data.NewPassword);
                dataUser.Password = hashPassNew;
                _base.users.Update(dataUser);
                _base.Commit();
                return Success("Đổi mật khẩu thành công");
            }
            catch (Exception ex)
            {
                return Error("Lỗi " + ex);
            }
        }
        [HttpGet]
        public IActionResult Profile()
        {
            User model = _base.users.GetByID(GetUser().CustomerId);
            return View(model);
        }
        [HttpPost]
        public JsonResult Profile(User data)
        {
            try
            {
                var entity = _base.users.GetByID(GetUser().CustomerId);
                if(entity == null)
                {
                    return Error("Không tìm thấy thông tin tài khoản của bạn");
                }
                entity.Name = data.Name;
                entity.Birth = data.Birth;
                entity.Phone = data.Phone;
                entity.Gender = data.Gender;
                _base.users.Update(entity);
                _base.Commit();
                return Success("Thay đổi thông tin thành công");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
    }
}
