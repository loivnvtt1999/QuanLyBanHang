using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Table;
using QuanLyBanHang.Models;
namespace QuanLyBanHang.Controllers
{
    public class ProductsController : Controller
    {
        private QuanLyBanHangDataContext db = new QuanLyBanHangDataContext();
        xulySanPham xlSP = new xulySanPham();
        xulyChiTietHoaDon xlCTHD = new xulyChiTietHoaDon();
        xuLyHoaDon xlHD = new xuLyHoaDon();
        xulyKhachHang xlKH = new xulyKhachHang();
        // GET: Products
        public ActionResult Index()
        {
            //Session.Remove("spmua");
            Session.Remove("dathangthanhcong");
            //Session.Remove("faillogin");
            var products = db.Products.Include(p => p.GetCategory).Include(p => p.GetSupplier);
            return View(products.ToList());
        }
        public ActionResult TestAjax()
        {
            return View();
        }
        public ActionResult TestAjax1()
        {
            System.Threading.Thread.Sleep(2000);
            return Content("aaaaa");
        }
        public ActionResult TimKiem(string ProductName)
        {
            //System.Threading.Thread.Sleep(2000);
            if (ProductName == null)
            {
                Session["sai"] = "Vui lòng nhập vào tên sản phẩm";
                return RedirectToAction("Index", "Products");
            }
            else
            {
                Product pro = xlSP.timKiemSanPham(ProductName.Trim());
                if (pro == null)
                {
                    Session["sai"] = "Không tìm thấy sản phẩm";
                    return RedirectToAction("Index", "Products");
                }
                else
                    return View(pro);
            }
        }
        public bool KiemTraKhachHangDaMuaSanPham(int makhach, int? ma)
        {
            List<Order> order = xlHD.layDanhSachHoaDonTheoKhachHang(makhach);
            if (order != null && order.Count>0)
            {
                foreach (var item in order)
                {
                    List<OrderDetail> lstod = xlCTHD.layDanhSachChiTietTheoHoaDon(item.OrderID);
                    if (lstod.Count > 0)
                    {
                        foreach (var item2 in lstod)
                        {
                            if (item2.ProductID == ma)
                                return true;
                        }
                    }
                }
            }
            return false;
        }
        // GET: Products/Details/5
        [HttpGet]
        public ActionResult ChiTietSanPham(int? ma)
        {
            if (Session["dung"] != null)
                Session.Remove("dung");
            else
            {
                if (Session["user"] != null)
                {
                    string usernamelogin = Session["user"].ToString();
                    Customer c = xlKH.layKhachHangTheoUserName(usernamelogin);
                    bool KT = KiemTraKhachHangDaMuaSanPham(c.CustomerID, ma);
                    if (KT == true)
                        Session["dung"] = "damua";
                }
            }
            if (ma == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = xlSP.chiTietSanPham(Int32.Parse(ma.ToString()));
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult danhSachFeedBack(int? masp)
        {
            if (masp == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Feedback> lstFeedback = xlSP.layFeedbackTheoSanPham(Int32.Parse(masp.ToString()));
            if (lstFeedback.Count == 0) 
            {
                ViewBag.chuacofeedback = "Sản phẩm chưa có bình luận nào";
                return View(lstFeedback);
            }
            else
                return View(lstFeedback);
                
        }
        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,ProductImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,ProductImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "CompanyName", product.SupplierID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
