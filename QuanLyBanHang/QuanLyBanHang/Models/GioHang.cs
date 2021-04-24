using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class GioHang
    {
        public int maSanPhamMua { get; set; }
        public string tenSanPhamMua { get; set; }
        public double giaSanPhamMua { get; set; }
        public int soLuongSanPhamMua { get; set; }
        public string hinhanhSanPham { get; set; }
        public double thanhtien()
        {
            return this.soLuongSanPhamMua * this.giaSanPhamMua;
        }
    }
}