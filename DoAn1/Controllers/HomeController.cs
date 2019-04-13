using DoAn1.App_Data;
using DoAn1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn1.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            using (var db = new DbContext())
            {
                var list = db.Sach.Where(p => !p.isDeleted).OrderByDescending(p => p.id).ToList();
                ViewBag.ListBook = list;
                if (list.Count() == 0)
                    ViewBag.Messenge = "Không tìm được sách theo yêu cầu!";
            }
            return View();
        }

        public ActionResult SearchBook(string searchString)
        {
            using (var db = new DbContext())
            {
                var books = from l in db.Sach 
                            select l;

                if (!String.IsNullOrEmpty(searchString))
                {
                    books = books.Where(s => s.TenSach.Contains(searchString)); 
                }
                ViewBag.ListBook = books.ToList();
                if (books.Count() == 0)
                    ViewBag.Messenge = "Không tìm được sách theo yêu cầu!";
                return View();
            }
        }


        public ActionResult CategoryBook(string categoryString)
        {
            using (var db = new DbContext())
            {
                var books = from l in db.Sach
                            select l;

                if (!String.IsNullOrEmpty(categoryString))
                {
                    books = books.Where(s => s.ChuDe.Contains(categoryString));
                }
                ViewBag.ListBook = books.ToList();
                if (books.Count() == 0)
                    ViewBag.Messenge = "Không tìm được sách theo yêu cầu!";
                return View();
            }
        }

        public ActionResult Detail(int id)
        {
            if (TempData["messenge"] != null)
                ViewBag.Messenge = TempData["messenge"].ToString();
            try
            {
                using (var db = new DbContext())
                {
                    var book = db.Sach.Where(p => p.id == id).FirstOrDefault();                  
                    if (book == null)
                    {
                        ViewBag.Messenge = "Không tìm được sách theo yêu cầu!";
                    }
                    else
                        ViewBag.Book = book;
                    return View();
                }
            }
            catch
            {
                ViewBag.Messenge = "Không tìm được sách theo yêu cầu!";
                return View();
            }
        }

        [HttpPost]
        public ActionResult AddCart(int id)
        {
            try
            {
                var helper = new GioHangHelper();
                if (Session.Count == 0)
                {
                    TempData["messenge"] = "Vui lòng đăng nhập!";
                    return Redirect(Url.Content("~/Login"));
                }
                else
                {
                    var user = (LoginModel)HttpContext.Session["User"];
                    using (var db = new DbContext())
                    {
                        if (!helper.isGioHangTonTai(user.TaiKhoan))
                        {
                            helper.TaoGioHang(user.TaiKhoan);
                            helper.ThemSanPham(id, user.TaiKhoan);
                        }
                        else
                        {
                            helper.ThemSanPham(id, user.TaiKhoan);
                        }
                    }
                    TempData["messenge"] = "Thêm vào giỏ hàng thành công!";
                    return Redirect(Request.UrlReferrer.PathAndQuery);
                }
            }
            catch {
                ViewBag.Messenge = "Some thing wong";
                return Redirect(Request.UrlReferrer.PathAndQuery);
            }
        }

        public ActionResult CartDetail()
        {
            var helper = new GioHangHelper();
            try
            {
                if (Session.Count == 0)
                {
                    TempData["messenge"] = "Vui lòng đăng nhập!";
                    return Redirect(Url.Content("~/Login"));
                }
                else
                {
                    var user = (LoginModel)HttpContext.Session["User"];
                    ViewBag.ListBook = helper.ChiTietGioHang(user.TaiKhoan);
                    ViewBag.TongGia = helper.TongTienGioHang(user.TaiKhoan);
                    if(helper.ChiTietGioHang(user.TaiKhoan).Count==0)
                        TempData["listemptyMessage"] = "No results";
                    return View();
                }
            }
            catch
            {

                throw;
            }
        }

        public ActionResult RemoveCart(int id)
        {
            try
            {
                var helper = new GioHangHelper();
                if (Session.Count == 0)
                {
                    TempData["messenge"] = "Vui lòng đăng nhập!";
                    return Redirect(Url.Content("~/Login"));
                }
                else
                {
                    var user = (LoginModel)HttpContext.Session["User"];
                    helper.XoaSanPham(id, user.TaiKhoan);
                    ViewBag.Messenge = "Xoá sản phẩm thành công!";
                    return Redirect(Request.UrlReferrer.PathAndQuery);
                }
            }
            catch
            {
                ViewBag.Messenge = "Some thing wong";
                return Redirect(Request.UrlReferrer.PathAndQuery);
            }
        }

    }
}