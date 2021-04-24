using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Table;
using QuanLyBanHang.Models;
namespace QuanLyBanHang.Controllers
{
    public class OrdersController : Controller
    {
        xuLyHoaDon xlHd = new xuLyHoaDon();
        xulyKhachHang xlyKh = new xulyKhachHang();
        xulyChiTietHoaDon xlCTHD = new xulyChiTietHoaDon();
        // GET: Orders
        public ActionResult DatHang()
        {
            if (Session["login"] == null)
            {
                Session["chuadn"] = "Bạn chưa đăng nhập vui lòng đăng nhập để mua hàng";
                return RedirectToAction("Index", "GioHang");
            }
            return View();  
        }
        [HttpPost]
        public ActionResult DatHang(Order order)
        {
            Order order1 = new Order();
            //Random r = new Random();
            //int ma = r.Next(10000);
            //for (int i = 0; i < 10000; i++)
            //{
            //    if (ma == i)
            //        ma = r.Next(10000);
            //}
            //order1.OrderID = ma;
            order1.OrderDate = DateTime.Today;
            order1.RequiredDate = DateTime.Today.AddDays(14);
            order1.Freight = null;
            order1.ShippedDate = DateTime.Today.AddDays(14);
            string s = Session["user"].ToString();
            order1.CustomerID = xlyKh.layKhachHangTheoUserName(s).CustomerID;
            order1.ShipAddress = order.ShipAddress;
            //Tạo hóa đơn
            int kq = xlHd.themHoaDon(order1);
            //Tạo các chi tiết hóa đơn
            List<GioHang> lstspmua;
            if (Session["spmua"] == null)
            {
                lstspmua = new List<GioHang>();
            }
            else
            {
                lstspmua = (List<GioHang>)Session["spmua"];
            }
            foreach (var item in lstspmua)
            {
                OrderDetail od = new OrderDetail();
                od.OrderID = order1.OrderID;
                od.ProductID = item.maSanPhamMua;
                od.Quantity = item.soLuongSanPhamMua;
                od.UnitPrice = item.giaSanPhamMua;
                xlCTHD.themChiTietHoaDon(od);
            }
            lstspmua.Clear();
            Session["dathangthanhcong"] = "Đã đặt hàng thành công";
            Session["soluong"] = lstspmua.Count;
            Session["spmua"] = lstspmua;
            return RedirectToAction("Index","GioHang");
        }
    }
}