using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table;
using DAL;
namespace BUS
{
    public class busTaiKhoan
    {
        QuanLyBanHangDataContext db = new QuanLyBanHangDataContext();
        public Account DangNhap(string tendn, string mk)
        {
            Account acc = db.Accounts.Where(x => x.UserName == tendn && x.Password == mk).FirstOrDefault();
            if (acc == null)
                return null;
            return acc;
        }
        public Account DangNhapAdmin(string tendn, string mk)
        {
            Account acc = db.Accounts.Where(x => x.UserName == tendn && x.Password == mk && x.Type=="admin").FirstOrDefault();
            if (acc == null)
                return null;
            return acc;
        }
        public int DoiMatKhau(int matk, string mkcu, string mkmoi)
        {
            Account acc = db.Accounts.Where(x => x.AccountID==matk && x.Password==mkcu).FirstOrDefault();
            if (acc == null)
                return 0;
            acc.Password = mkmoi;
            db.SaveChanges();
            return 1;
        }
        public int DangKy(Account acc)
        {
            Account acckt = db.Accounts.Where(x => x.UserName == acc.UserName).FirstOrDefault();
            if (acckt != null)
                return 0;
            db.Accounts.Add(acc);
            db.SaveChanges();
            return 1;
        }
    }
}
