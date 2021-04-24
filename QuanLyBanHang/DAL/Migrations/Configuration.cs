namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Table;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.QuanLyBanHangDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.QuanLyBanHangDataContext context)
        {
            #region Nhập dữ liệu Customer
            context.Customers.Add(new Customer()
            {
                CustomerID = 1,
                UserName = "nguyen",
                Password = "1",
                ContactName = "Trương Đình Nguyên",
                Address = "904/42 Nguyễn Kiệm, P3, Q.Gò vấp, Tp.HCM",
                Phone = "0388917506"
            });
            context.Customers.Add(new Customer()
            {
                CustomerID = 2,
                UserName = "loi",
                Password = "1",
                ContactName = "Phạm Đức Lợi",
                Address = "904/42 Nguyễn Kiệm, P3, Q.Gò vấp, Tp.HCM",
                Phone = "0388917099"
            });
            #endregion

            #region Nhập dữ liệu Category
            context.Categories.Add(new Category
            {
                CategoryID = 1,
                CategoryName = "Điện thoại",
                Description = ""
            });
            context.Categories.Add(new Category
            {
                CategoryID = 2,
                CategoryName = "Laptop",
                Description = ""
            });
            context.Categories.Add(new Category
            {
                CategoryID = 3,
                CategoryName = "Máy để bàn",
                Description = ""
            });
            context.Categories.Add(new Category
            {
                CategoryID = 4,
                CategoryName = "USB",
                Description = ""
            });
            context.Categories.Add(new Category
            {
                CategoryID = 5,
                CategoryName = "Tivi",
                Description = ""
            });
            context.Categories.Add(new Category
            {
                CategoryID = 6,
                CategoryName = "Máy lạnh",
                Description = ""
            });
            #endregion

            #region Nhập dữ liệu Supplier
            context.Suppliers.Add(new Supplier()
            {
                SupplierID = 1,
                CompanyName = "XanuForest",
                Phone = "0388917506",
                Address = "12 Nguyễn Văn Bảo, P4, Q.Gò Vấp, Tp.HCM"
            });
            context.Suppliers.Add(new Supplier()
            {
                SupplierID = 2,
                CompanyName = "ThreeBlue",
                Phone = "0388917099",
                Address = "12 Nguyễn Văn Bảo, P4, Q.Gò Vấp, Tp.HCM"

            });
            #endregion

            #region Nhập dữ liệu Product
            context.Products.Add(new Product()
            {
                ProductID = 1,
                CategoryID = 1,
                SupplierID = 1,
                ProductName = "Vsmart Live (4GB/64GB)",
                QuantityPerUnit = 100,
                UnitPrice = 3590000,
                ProductImage = "Sp1.jpg"
            });
            context.Products.Add(new Product()
            {
                ProductID = 2,
                CategoryID = 2,
                SupplierID = 1,
                ProductName = "Laptop Gaming MSI Alpha A3DDK 212VN",
                QuantityPerUnit = 100,
                UnitPrice = 19990000,
                ProductImage = "Sp2.jpg"
            });
            context.Products.Add(new Product()
            {
                ProductID = 3,
                CategoryID = 3,
                SupplierID = 1,
                ProductName = "GVN Volibear S",
                QuantityPerUnit = 100,
                UnitPrice = 25590000,
                ProductImage = "Sp3.jpg"
            });
            context.Products.Add(new Product()
            {
                ProductID = 4,
                CategoryID = 1,
                SupplierID = 2,
                ProductName = "Điện thoại Xiaomi Redmi 9 (4GB/64GB)",
                QuantityPerUnit = 100,
                UnitPrice = 3790000,
                ProductImage = "Sp4.jpg"
            });
            context.Products.Add(new Product()
            {
                ProductID = 5,
                CategoryID = 2,
                SupplierID = 2,
                ProductName = "Laptop ASUS ROG Strix G15 G512 IAL011T",
                QuantityPerUnit = 100,
                UnitPrice = 28990000,
                ProductImage = "Sp5.jpg"
            });
            #endregion

            #region Nhập dữ liệu Order
            context.Orders.Add(new Order()
            {
                OrderID = 1,
                CustomerID = 1,
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(7),
                ShippedDate = DateTime.Now.AddDays(6),
                Freight = "Xe máy",
                ShipAddress = "904/42 Nguyễn Kiệm, P3, Q.Gò vấp, Tp.HCM"
            });
            context.Orders.Add(new Order()
            {
                OrderID = 2,
                CustomerID = 2,
                OrderDate = DateTime.Now.AddDays(-1),
                RequiredDate = DateTime.Now.AddDays(6),
                ShippedDate = DateTime.Now.AddDays(6),
                Freight = "Xe máy",
                ShipAddress = "904/42 Nguyễn Kiệm, P3, Q.Gò vấp, Tp.HCM"
            });
            #endregion

            #region Nhập dữ liệu Oder_Detail
            context.OrderDetails.Add(new OrderDetail
            {
                OrderID = 1,
                ProductID = 1,
                Quantity = 5,
                UnitPrice = 5000000
            });
            context.OrderDetails.Add(new OrderDetail
            {
                OrderID = 1,
                ProductID = 2,
                Quantity = 5,
                UnitPrice = 5000000
            });
            context.OrderDetails.Add(new OrderDetail
            {
                OrderID = 2,
                ProductID = 1,
                Quantity = 4,
                UnitPrice = 5000000
            });
            context.OrderDetails.Add(new OrderDetail
            {
                OrderID = 2,
                ProductID = 2,
                Quantity = 5,
                UnitPrice = 5000000
            });
            #endregion

            #region Nhập dữ liệu Feedback

            #endregion

            #region Nhập dữ liệu Account
            context.Accounts.Add(new Account()
            {
                AccountID = 1,
                UserName = "admin",
                Password = "123",
                FullName = "Trương Đình Nguyên",
                Type = "admin"
            });

            context.Accounts.Add(new Account()
            {
                AccountID = 2,
                UserName = "nguyen",
                Password = "1",
                FullName = "Trương Đình Nguyên",
                Type = "user"
            });

            context.Accounts.Add(new Account()
            {
                AccountID = 3,
                UserName = "loi",
                Password = "1",
                FullName = "Phạm Đức Lợi",
                Type = "user"
            });
            #endregion
        }
    }
}
