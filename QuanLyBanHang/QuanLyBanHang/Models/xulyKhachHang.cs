using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Table;
using BUS;
namespace QuanLyBanHang.Models
{
    public class xulyKhachHang
    {
        busKhachHang busKh = new busKhachHang();
        public Customer layKhachHangTheoUserName(string username)
        {
            return busKh.layKhachHangTheoUserName(username);
        }
        public int themKH(Customer c)
        {
            return busKh.themKH(c);
        }
    }
}