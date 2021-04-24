using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BUS;
using Table;

namespace QuanLyBanHang.Models
{
    public class xuLyHoaDon
    {
        busHoaDon busHD = new busHoaDon();
        public int themHoaDon(Order odr)
        {
            return busHD.themHoaDon(odr);
        }
        public List<Order> layDanhSachHoaDonTheoKhachHang(int maKhach)
        {
            return busHD.layDanhSachHoaDonTheoKhachHang(maKhach);
        }
    }
}