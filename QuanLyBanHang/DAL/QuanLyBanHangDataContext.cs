namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Table;
    public class QuanLyBanHangDataContext : DbContext
    {
        // Your context has been configured to use a 'QuanLyBanHangDataContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.QuanLyBanHangDataContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QuanLyBanHangDataContext' 
        // connection string in the application configuration file.
        public QuanLyBanHangDataContext()
            : base("QuanLyBanHangDataContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Account> Accounts { get; set; }
         public virtual DbSet<Category> Categories { get; set; }
         public virtual DbSet<Supplier> Suppliers { get; set; }
         public virtual DbSet<Product> Products { get; set; }
         public virtual DbSet<Customer> Customers { get; set; }
         public virtual DbSet<Order> Orders { get; set; }
         public virtual DbSet<OrderDetail> OrderDetails { get; set; }
         public virtual DbSet<Feedback> Feedbacks { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}