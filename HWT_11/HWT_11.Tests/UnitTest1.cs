namespace HWT_11.Tests
{
    using System.Collections.Generic;
    using Classes;
    using HWT_11;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Data;
    using System.Data.SqlClient;
    using System;
    using System.Configuration;

    [TestClass]
    public class UnitTest1
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;

        [TestMethod]
        public void GetOrdersTest()
        {
            DAL dal = new DAL();
            List<Order> orders = dal.GetOrders();

            foreach (var order in orders)
            {
                Assert.IsNotNull(order);
            }
        }

        [TestMethod]
        public void GetInfoOrderTest()
        {
            DAL dal = new DAL();

            List<OrderDetails> orderDetails = dal.GetInfoOrder(10248);

            foreach (var orderDet in orderDetails)
            {
                Assert.IsNotNull(orderDet);
            }
        }

        [TestMethod]
        public void CreateOrderTest()
        {
            DAL dal = new DAL();
            List<Order> orders = dal.GetOrders();

            dal.CreateNewOrder(
                "VINET",
                4,
                new DateTime(1900, 01, 01),
                new DateTime(1900, 01, 01),
                new DateTime(1900, 01, 01),
                1,
                67,
                "North/South",
                "South House 300 Queensbridge",
                "New York",
                "NY",
                87110,
                "USA");

            Assert.IsTrue(orders.Count < dal.GetOrders().Count);

            ///DeleteOrder();
        }

        [TestMethod]
        public void SetOrderDateTest()
        {
            DAL dal = new DAL();
            this.CreateOrderTest();

            List<Order> orders = dal.GetOrders();
            DateTime? date = DateTime.Now.Date;
            dal.SetOrderDate(date, orders[orders.Count - 1].OrderID);

            orders = dal.GetOrders();
            DateTime? date2 = orders[orders.Count - 1].OrderDate;
            Assert.AreEqual(date, date2);

            this.DeleteOrder();
        }

        [TestMethod]
        public void SetShippedDateTest()
        {
            DAL dal = new DAL();
            this.CreateOrderTest();

            List<Order> orders = dal.GetOrders();
            DateTime? date = DateTime.Now.Date;
            dal.SetShippedDate(date, orders[orders.Count - 1].OrderID);

            orders = dal.GetOrders();
            DateTime? date2 = orders[orders.Count - 1].ShippedDate;
            Assert.AreEqual(date, date2);

            this.DeleteOrder();
        }

        [TestMethod]
        public void ViewCustOrderHistTest()
        {
            DAL dal = new DAL();
            List<CustOrderHist> custOrderHist = dal.ViewCustOrderHist("TORTU");
            Assert.IsTrue(custOrderHist.Count > 0);
            ////Assert.AreEqual(custOrderHist.Count, 24);
        }

        [TestMethod]
        public void ViewCustOrdersDetailTest()
        {
            DAL dal = new DAL();
            List<CustOrdersDetail> custOrdersDetail = dal.ViewCustOrdersDetail(11070);
            Assert.IsTrue(custOrdersDetail.Count > 0);
        }


        public void DeleteOrder()
        {
            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"DELETE FROM Northwind.Orders
                      WHERE OrderID > 11077";

                int number = command.ExecuteNonQuery();
            }
        }
    }

}
