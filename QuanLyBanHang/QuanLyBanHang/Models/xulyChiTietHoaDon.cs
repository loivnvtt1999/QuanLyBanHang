using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BUS;
using Table;
namespace QuanLyBanHang.Models
{
    public class xulyChiTietHoaDon
    {
        busChiTietHoaDon busCTHD = new busChiTietHoaDon();
        public int themChiTietHoaDon(OrderDetail odrDetail)
        {
            return busCTHD.themChiTietHoaDon(odrDetail);
        }
        public List<OrderDetail> layDanhSachChiTietTheoHoaDon(int maHD)
        {
            return busCTHD.layDanhSachChiTietTheoHoaDon(maHD);
        }
    }
}