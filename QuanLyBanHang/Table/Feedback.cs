using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }
        public string FeedbackTitle { get; set; }
        public string FeedbackContent { get; set; }
        public DateTime FeedbackDate { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public virtual Customer GetCustomer { get; set; }
        public virtual Product GetProduct { get; set; }
    }
}
