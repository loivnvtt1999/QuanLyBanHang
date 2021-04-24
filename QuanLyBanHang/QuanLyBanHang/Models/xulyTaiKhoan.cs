using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BUS;
using Table;

namespace QuanLyBanHang.Models
{
    public class xulyTaiKhoan
    {
        busTaiKhoan busTK = new busTaiKhoan();
        public Account DangNhap(string tendn, string mk)
        {
            return busTK.DangNhap(tendn, mk);
        }
        public int DoiMatKhau(int matk,string mkcu, string mkmoi)
        {
            return busTK.DoiMatKhau(matk, mkcu, mkmoi);
        }
        public int DangKy(Account acc)
        {
            return busTK.DangKy(acc);
        }
        public Account DangNhapAdmin(string tendn, string mk)
        {
            return busTK.DangNhapAdmin(tendn, mk);
        }
    }
}