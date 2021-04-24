using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BUS;
using Table;

namespace QuanLyBanHang.Models
{
    public class xulySanPham
    {
        busSanPham busSP = new busSanPham();
        public Product chiTietSanPham(int ma)
        {
            return busSP.chiTietSanPham(ma);
        }
        public List<Feedback> layFeedbackTheoSanPham(int masp)
        {
            return busSP.layFeedbackTheoSanPham(masp);
        }
        public Product timKiemSanPham(string tensp)
        {
            return busSP.timKiemSanPham(tensp);
        }
    }
}