using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Table;

namespace QuanLyBanHang.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        xulySanPham xlSP = new xulySanPham();
        // GET: SanPhamMua
        public ActionResult Index()
        {
            List<GioHang> lstspmua;
            if (Session["spmua"] == null)
            {
                lstspmua = new List<GioHang>();
            }
            else
            {
                lstspmua = (List<GioHang>)Session["spmua"];
            }
            if (lstspmua.Count == 0)
            {
                ViewBag.khong = "Giỏ hàng chưa có sản phẩm";
                return View(lstspmua);
            }
            else
                return View(lstspmua);
        }
        public ActionResult AddToCart(int? id)
        {
            Session.Remove("dathangthanhcong");
            List<GioHang> lstspmua;
            if (Session["spmua"] == null)
            {
                lstspmua = new List<GioHang>();
            }
            else
            {
                lstspmua = (List<GioHang>)Session["spmua"];
            }
            Product sp = xlSP.chiTietSanPham(Int32.Parse(id.ToString()));
            if (sp != null)
            {
                bool kt = false;
                foreach (var item in lstspmua)
                {
                    if (item.maSanPhamMua == sp.ProductID)
                    {
                        item.soLuongSanPhamMua++;
                        kt = true;
                    }
                }
                GioHang spmua = new GioHang();
                if (!kt)
                {
                    spmua.tenSanPhamMua = sp.ProductName;
                    spmua.giaSanPhamMua = sp.UnitPrice;
                    spmua.maSanPhamMua = sp.ProductID;
                    spmua.soLuongSanPhamMua = 1;
                    spmua.hinhanhSanPham = sp.ProductImage;
                    lstspmua.Add(spmua);
                }
                Session["soluong"] = lstspmua.Count;
                Session["spmua"] = lstspmua;
                Session["thanhtien"] = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", lstspmua.Sum(x => x.thanhtien()));
                return RedirectToAction("Index", "GioHang");
            }
            else
            {
                Response.StatusCode = 404;
                return null;
            }
        }  
        public ActionResult capNhatSoLuong(int maSanPhamMua, int soLuongSP)
        {
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
                if (item.maSanPhamMua == maSanPhamMua)
                {
                    item.soLuongSanPhamMua = soLuongSP;
                }
            }
            Session["soluong"] = lstspmua.Count;
            Session["spmua"] = lstspmua;
            Session["thanhtien"] =string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", lstspmua.Sum(x=>x.thanhtien()));
            return RedirectToAction("Index", "GioHang");
        }
        public ActionResult xoaSanPham(int maSanPhamMua)
        {
            List<GioHang> lstspmua;
            if (Session["spmua"] == null)
            {
                lstspmua = new List<GioHang>();
            }
            else
            {
                lstspmua = (List<GioHang>)Session["spmua"];
            }
            GioHang sp = new GioHang();
            foreach (var item in lstspmua)
            {
                if (item.maSanPhamMua.Equals(maSanPhamMua))
                    sp = item;
            }
            lstspmua.Remove(sp);
            Session["soluong"] = lstspmua.Count;
            Session["spmua"] = lstspmua;
            Session["thanhtien"] = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", lstspmua.Sum(x => x.thanhtien()));
            return RedirectToAction("Index", "GioHang");
        }
    }
}