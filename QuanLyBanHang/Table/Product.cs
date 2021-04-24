using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public int QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public string ProductImage { get; set; }
        public virtual Supplier GetSupplier { get; set; }
        public virtual Category GetCategory { get; set; }
    }
}
