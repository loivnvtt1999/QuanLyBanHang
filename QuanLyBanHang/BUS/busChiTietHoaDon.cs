using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table;
using DAL;
namespace BUS
{
    public class busChiTietHoaDon
    {
        QuanLyBanHangDataContext db = new QuanLyBanHangDataContext();
        public int themChiTietHoaDon(OrderDetail odrDetail)
        {
            db.OrderDetails.Add(odrDetail);
            db.SaveChanges();
            return 1;
        }
        public List<OrderDetail> layDanhSachChiTietTheoHoaDon(int maHD)
        {
            return db.OrderDetails.Where(x => x.OrderID == maHD).ToList();
        }
    }
}
