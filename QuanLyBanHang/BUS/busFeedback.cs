using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Table;
using DAL;
namespace BUS
{
    public class busFeedback
    {
        QuanLyBanHangDataContext db = new QuanLyBanHangDataContext();
        public int themFeedback( Feedback fb)
        {
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return 1;
        }
    }
}
