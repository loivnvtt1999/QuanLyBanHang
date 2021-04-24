using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BUS;
using QuanLyBanHang.Models;
using Table;

namespace QuanLyBanHang.Controllers
{
    public class AccountController : Controller
    {
        xulyTaiKhoan xlTK = new xulyTaiKhoan();
        xulyKhachHang xlKH = new xulyKhachHang();
        // GET: Account
        [HttpGet]
        public ActionResult DoiMatKhau()
        {
            return View();
        }
        public ActionResult DangNhapAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhapAdmin(string UserName, string Password)
        {
            Account kq = xlTK.DangNhapAdmin(UserName, Password);
            if (kq == null)
            {
                Session["failloginadmin"] = "Thông tin đăng nhập chưa chính xác, vui lòng kiểm tra lại";
                return RedirectToAction("DangNhapAdmin", "Account");
            }
            else
            {
                FormsAuthentication.SetAuthCookie(kq.Type, true);
                Session["accountidadmin"] = kq.AccountID;
                Session["useradmin"] = kq.UserName;
                Session["loginadmin"] = kq.FullName;
                return RedirectToAction("Index", "ProductsManager");
            }
        }
        public PartialViewResult QuanLy()
        {
            return PartialView();
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(string TenDayDu, string DiaChi, string SDT, string TenDangNhap, string MatKhau)
        {
            Account acc = new Account();
            acc.FullName = TenDayDu;
            acc.Password = MatKhau;
            acc.UserName = TenDangNhap;
            acc.Type = "user";
            int addAcc = xlTK.DangKy(acc);
            if (addAcc == 1)
            {
                Customer c = new Customer();
                c.ContactName = TenDayDu;
                c.UserName = TenDangNhap;
                c.Password = MatKhau;
                c.Address = DiaChi;
                c.Phone = SDT;
                int addUser = xlKH.themKH(c);
                if (addUser == 1)
                {
                    Session["accountid"] = acc.AccountID;
                    Session["user"] = acc.UserName;
                    Session["login"] = acc.FullName;
                }
                return RedirectToAction("Success", "Account");
            }
            else
            {
                ViewBag.trungtendn = "Tên đăng nhập đã tồn tại vui lòng kiểm tra lại";
                return View();
            }
                
                
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult DoiMatKhau(string mkcu, string mkmoi)
        {
            int kq = xlTK.DoiMatKhau(int.Parse(Session["accountid"].ToString()), mkcu, mkmoi);
            if (kq == 1)
            {
                ViewBag.doithanhcong = "Đổi mật khẩu thành công";
                return View();
            }
            else
            {
                ViewBag.thatbai = "Đổi mật khẩu thất bại";
                return View(); 
            }
        }
        [HttpPost]
        public ActionResult DangNhap(string UserName, string Password)
        {
            Account kq = xlTK.DangNhap(UserName, Password);
            if (kq == null)
            {
                Session["faillogin"] = "Thông tin đăng nhập chưa chính xác, vui lòng kiểm tra lại";
                return RedirectToAction("Index", "Products");
            }
            else
            {
                //FormsAuthentication.SetAuthCookie(kq.Type, true);
                Session.Remove("chuadn");
                Session["accountid"] = kq.AccountID;
                Session["user"] = kq.UserName;
                Session["login"] = kq.FullName;
                return RedirectToAction("Index", "Products");
            }
        }
        public ActionResult DangXuat()
        {
            Session.Remove("spmua");
            //Session.Remove("dung");
            Session.Remove("accountid");
            Session.Remove("user");
            Session.Remove("login");
            Session.Remove("faillogin");
            return RedirectToAction("Index", "Products");
        }
        public ActionResult DangXuatAdmin()
        {
            FormsAuthentication.SignOut();
            Session.Remove("accountidadmin");
            Session.Remove("useradmin");
            Session.Remove("loginadmin");
            Session.Remove("failloginadmin");
            return RedirectToAction("Index", "ProductsManager");
        }
    }
}