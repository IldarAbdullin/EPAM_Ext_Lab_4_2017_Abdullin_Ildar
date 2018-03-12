namespace HWT_11.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class DAL
    {
        private string connectionString;

        public DAL()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString;
        }

        public enum OrderStatus
        {
            Delivered,
            NotShipped
        }

        public List<Order> GetOrders()
        {
            var orders = new List<Order>();
            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Northwind.Orders";
                connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ////перепробывал и иницилиазатором и так уже, не понимаю, что не так, я пытался...
                        //// Orders.Add(new Order(
                        ////   reader.GetInt32(0) //OrderID
                        //// , reader.GetString(1)//CustomerID
                        //// , reader.GetInt32(2)//EmployeeID
                        //// , reader.GetDateTime(3)//OrderDate
                        //// , reader.GetDateTime(4)//ShippedDate
                        //// , reader.GetString(5)//ShipAddress
                        ////));
                    }
                }
            }

            return orders;
        }

        public List<OrderDetails> GetInfoOrder(int ordersID)
        {
            string commandString = @"Select Orders.OrderID, 
                                            Orders.CustomerID, 
                                            Orders.EmployeeID,
                                            Orders.OrderDate,
                                            Orders.ShippedDate,
                                            Orders.ShipAddress, 
                                            [Order Details].ProductID, 
                                            [Order Details].Quantity,
                                            [Order Details].UnitPrice, 
                                            [Order Details].Discount, 
                                            Products.ProductID, 
                                            Products.ProductName
                                    from(Northwind.Orders join Northwind.[Order Details]
                                    on Orders.OrderID = [Order Details].OrderID) 
                                    join Northwind.Products 
                                    on[Order Details].ProductID = Products.ProductID" +
                                    $"Where Orders.OrderID = {ordersID}";

            var infoOrders = new List<OrderDetails>();
            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = commandString;
                command.CommandType = CommandType.Text;

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ////пытался сделать через иницилиазатор,но он почему то не принимал и писал:
                    ////отсутствует аргумент соответствующий требуемому формальному параметру 
                    ////infoOrders.Add(new OrderDetails
                    ////{
                    ////    OrderID = (int)reader["OrderID"],
                    ////    CustomerID = (int)reader["CustomerID"],
                    ////    EmployeeID = (int)reader["EmployeeID"],
                    ////    OrderDate = (DateTime)reader["OrderDate"],
                    ////    ShippedDate = (DateTime)reader["ShippedDate"],
                    ////    ShipAddress = (string)reader["ShipAddress"],
                    ////    ProductID = (int)reader["ProductID"],
                    ////    Quantity = (int)reader["Quantity"],
                    ////    UnitPrice = (int)reader["UnitPrice"],
                    ////    Discount = (int)reader["Discount"],
                    ////    ProductName = (string)reader["ProductName"]
                    ////});
                }
            }

            return infoOrders;
        }

        public void CreateNewOrder(string custmerID, int employeeID, DateTime orderDate, string requiueredDate, DateTime? shippedDate, int shipVia, double freight, string shipName, string shipAdress, string shipCity, string shipRegion, int shipPostalCode, string shipCountry)
        {
            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = $"insert into Northwind.Orders values ('{custmerID}', {employeeID},{orderDate}, {requiueredDate}," +
                                      $" {shippedDate}, {shipVia}, {freight}, '{shipName}', '{shipAdress}'," +
                                      $"'{shipCity}', '{shipRegion}', {shipPostalCode}, '{shipCountry}');";

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void SetOrderDate(DateTime? date, int orderID)
        {
            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"UPDATE Northwind.Orders 
                    SET OrderDate = CONVERT(DATETIME, '" +
                    date +
                    "', 103) WHERE OrderID = @OrderID";

                this.Parameter(command, "@OrderID", orderID, DbType.Int32);

                int number = command.ExecuteNonQuery();
            }
        }

        public void SetShippedDate(DateTime? date, int orderID)
        {
            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"UPDATE Northwind.Orders 
                    SET ShippedDate = CONVERT(DATETIME, '" +
                    date +
                    "', 103) WHERE OrderID = @OrderID AND OrderDate IS NOT NULL";

                this.Parameter(command, "@OrderID", orderID, DbType.Int32);

                int number = command.ExecuteNonQuery();
            }
        }

        public List<CustOrderHist> ViewCustOrderHist(string customerID)
        {
            List<CustOrderHist> custOrderHist = new List<CustOrderHist>();

            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "Northwind.CustOrderHist";
                command.CommandType = CommandType.StoredProcedure;

                this.Parameter(command, "@CustomerID", customerID, DbType.String);

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string productName = reader.GetString(0);
                        int total = reader.GetInt32(1);

                        custOrderHist.Add(new CustOrderHist(productName, total));
                    }
                }

                return custOrderHist;
            }
        }

        public List<CustOrdersDetail> ViewCustOrdersDetail(int orderID)
        {
            List<CustOrdersDetail> custOrdersDetail = new List<CustOrdersDetail>();

            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = "Northwind.CustOrdersDetail";
                command.CommandType = CommandType.StoredProcedure;

                this.Parameter(command, "@OrderID", orderID, DbType.Int32);

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string productName = reader.GetString(0);
                        decimal unitPrice = reader.GetDecimal(1);
                        int quantity = reader.GetInt16(2);
                        int discount = reader.GetInt32(3);
                        decimal extendedPrice = reader.GetDecimal(4);

                        custOrdersDetail.Add(new CustOrdersDetail(productName, unitPrice, quantity, discount, extendedPrice));
                    }
                }

                return custOrdersDetail;
            }
        }

        public void Parameter<T>(IDbCommand command, string name, T value, DbType type)
        {
            IDbDataParameter param = command.CreateParameter();
            param.ParameterName = name;
            param.Value = value;
            param.DbType = type;
            command.Parameters.Add(param);
        }
    }
}
