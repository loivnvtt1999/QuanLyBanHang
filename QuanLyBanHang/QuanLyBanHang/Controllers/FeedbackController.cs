using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyBanHang.Models;
using Table;
namespace QuanLyBanHang.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        xulyFeedback xlFB = new xulyFeedback();
        xulyKhachHang xlKH = new xulyKhachHang();
        public ActionResult themFeedBack(string FeedbackTitle, string FeedbackContent, int ma)
        {
            Customer c= new Customer();
            if (Session["user"] != null)
            {
                string usernamelogin = Session["user"].ToString();
                c = xlKH.layKhachHangTheoUserName(usernamelogin);
            }
            Feedback fb = new Feedback();
            fb.FeedbackTitle = FeedbackTitle;
            fb.FeedbackContent = FeedbackContent;
            fb.CustomerID = c.CustomerID;
            fb.FeedbackDate = DateTime.Today;
            fb.ProductID = ma;
            int add = xlFB.themFeedback(fb);
            return RedirectToAction("ChiTietSanPham", "Products",new { ma=fb.ProductID });
        }
    }
}