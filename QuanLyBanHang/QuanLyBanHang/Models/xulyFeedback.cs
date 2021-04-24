using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BUS;
using Table;

namespace QuanLyBanHang.Models
{
    public class xulyFeedback
    {
        busFeedback busFB = new busFeedback();
        public int themFeedback(Feedback fb)
        {
            return busFB.themFeedback(fb);
        }
    }
}