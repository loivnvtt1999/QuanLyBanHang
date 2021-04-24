using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table;
using DAL;
namespace BUS
{
    public class busHoaDon
    {
        QuanLyBanHangDataContext db = new QuanLyBanHangDataContext();
        public int themHoaDon(Order odr)
        {
            db.Orders.Add(odr);
            db.SaveChanges();
            return 1;
        }
        public List<Order> layDanhSachHoaDonTheoKhachHang(int maKhach)
        {
            return db.Orders.Where(x => x.CustomerID == maKhach).ToList();
        }
    }
}
