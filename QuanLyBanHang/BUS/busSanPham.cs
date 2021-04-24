using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table;
using DAL;
namespace BUS
{
    public class busSanPham
    {
        QuanLyBanHangDataContext db = new QuanLyBanHangDataContext();
        public Product chiTietSanPham(int ma)
        {
            return db.Products.Where(x => x.ProductID == ma).FirstOrDefault();
        }
        public List<Feedback> layFeedbackTheoSanPham(int masp)
        {
            return db.Feedbacks.Where(x => x.ProductID == masp).ToList();
        }
        public Product timKiemSanPham(string tensp)
        {
            return db.Products.Where(x => x.ProductName == tensp).FirstOrDefault();
        }
    }
}
