using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table;
using DAL;
namespace BUS
{
    public class busKhachHang
    {
        QuanLyBanHangDataContext db = new QuanLyBanHangDataContext();
        public Customer layKhachHangTheoUserName(string username)
        {
            return db.Customers.Where(x => x.UserName == username).FirstOrDefault();
        }
        public int themKH (Customer c)
        {
            db.Customers.Add(c);
            db.SaveChanges();
            return 1;
        }
    }
}
