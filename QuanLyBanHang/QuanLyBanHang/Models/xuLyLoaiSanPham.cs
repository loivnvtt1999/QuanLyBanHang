using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BUS;
using Table;
namespace QuanLyBanHang.Models
{
    public class xuLyLoaiSanPham
    {
        busLoaiSanPham busLSP = new busLoaiSanPham();
        public List<Category> layDanhSachLoaiSanPham()
        {
            return busLSP.layDanhSachLoaiSanPham();
        }
        public List<Product> laySanPhamTheoLoai(int maloai)
        {
            return busLSP.laySanPhamTheoLoai(maloai);
        }
    }
}