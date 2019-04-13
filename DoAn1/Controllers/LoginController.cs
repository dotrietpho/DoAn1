using DoAn1.App_Data;
using DoAn1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            Session.RemoveAll();
            if (TempData["messenge"] != null)
            {
                ViewBag.Messenge = TempData["messenge"].ToString();
            }
            if (Session.Count>0)
                return  Redirect(Url.Content("~/"));
            return View();
        }

        [HttpPost]
        public ActionResult LoginCheck(LoginModel a)
        {
            using (var db = new DbContext())
            {
                var user = db.KhachHang.Where(p => p.TaiKhoan == a.TaiKhoan).FirstOrDefault();
                if (user != null && user.MatKhau == a.MatKhau)
                {
                    a.TenKH = user.TenKH;
                    Session["User"] = a;
                    return Redirect(Url.Content("~/"));
                }
                else
                {
                    TempData["messenge"] = "Sai tên đăng nhập hoặc mật khẩu!";
                    return RedirectToAction("Index");
                }

            }
        }
        public ActionResult Register()
        {
            if (Session.Count > 0)
                return Redirect(Url.Content("~/"));
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel a)
        {
            try
            {
                using (var db = new DbContext())
                {
                    var user = db.KhachHang.Where(p => p.TaiKhoan == a.TaiKhoan).FirstOrDefault();
                    if (user != null)
                    {
                        ViewBag.Messenge = "Tài khoản đã tồn tại!";
                        return View();
                    }
                    if (a.password == a.ReTypedpassword)
                    {
                        db.KhachHang.Add(new KhachHang(a.TaiKhoan, a.password, a.TenKH, a.SDT, a.NgaySinh));
                        db.SaveChanges();
                        Session["User"] = new LoginModel(a.TaiKhoan,a.password,a.TenKH) ;
                        return Redirect(Url.Content("~/"));
                    }
                    else
                    {
                        ViewBag.Messenge = "Mật khẩu nhập lại không đúng";
                        return View();
                    }

                }
            }
            catch
            {
                ViewBag.Messenge = "Some thing wong";
                return RedirectToAction("Register");
            }
        }
        [HttpGet]
        public ActionResult Logout(LoginModel a)
        {
            Session.RemoveAll();
            Session.Clear();
            return Redirect(Url.Content("~/"));
        }
    }
}