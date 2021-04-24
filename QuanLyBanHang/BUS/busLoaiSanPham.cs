using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Table;
namespace BUS
{
    public class busLoaiSanPham
    {
        QuanLyBanHangDataContext db = new QuanLyBanHangDataContext();
        public List<Category> layDanhSachLoaiSanPham()
        {
            return db.Categories.ToList();
        }
        public List<Product> laySanPhamTheoLoai(int maloai)
        {
            return db.Products.Where(x => x.CategoryID == maloai).ToList();
        }
    }
}
