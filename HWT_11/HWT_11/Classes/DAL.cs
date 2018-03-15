namespace HWT_11.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    public class DAL
    {
        private DateTime? dateNULL = null;

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
                command.CommandText = "SELECT Orders.OrderID, Orders.CustomerID, Orders.EmployeeID,Orders.OrderDate,Orders.ShippedDate,Orders.ShipAddress FROM Northwind.Orders Orders";
                connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int orderID = reader.GetInt32(0);
                        string customerID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        int employeeID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        DateTime? orderDate = reader.IsDBNull(3) ? this.dateNULL : reader.GetDateTime(3);
                        DateTime? shippedDate = reader.IsDBNull(4) ? this.dateNULL : reader.GetDateTime(4);
                        string shipAddress = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);

                        Order o = new Order
                        {
                            OrderID = orderID,
                            CustomerID = customerID,
                            EmployeeID = employeeID,
                            OrderDate = orderDate,
                            ShippedDate = shippedDate,
                            ShipAddress = shipAddress
                        };

                        orders.Add(o);
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
                                            Products.ProductName
                                    from(Northwind.Orders join Northwind.[Order Details]
                                    on Orders.OrderID = [Order Details].OrderID) 
                                    join Northwind.Products 
                                    on[Order Details].ProductID = Products.ProductID
                                    Where Orders.OrderID = @ordersID";

            var infoOrders = new List<OrderDetails>();
            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = commandString;
                this.Parameter(command, "@ordersID", ordersID, DbType.Int32);
                command.CommandType = CommandType.Text;

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int orderID = reader.GetInt32(0);
                        string customerID = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        int employeeID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                        DateTime? orderDate = reader.IsDBNull(3) ? this.dateNULL : reader.GetDateTime(3);
                        DateTime? shippedDate = reader.IsDBNull(4) ? this.dateNULL : reader.GetDateTime(4);
                        string shipAddress = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                        int productID = reader.GetInt32(6);
                        int quantity = reader.IsDBNull(7) ? 0 : reader.GetInt16(7);
                        decimal unitPrice = reader.IsDBNull(8) ? 0 : reader.GetDecimal(8);
                        float discount = reader.IsDBNull(9) ? 0 : reader.GetFloat(9);
                        string productName = reader.GetString(10);

                        OrderDetails od = new OrderDetails
                        {
                            OrderID = orderID,
                            CustomerID = customerID,
                            EmployeeID = employeeID,
                            OrderDate = orderDate,
                            ShippedDate = shippedDate,
                            ShipAddress = shipAddress,
                            ProductID = productID,
                            Quantity = quantity,
                            UnitPrice = unitPrice,
                            Discount = discount,
                            ProductName = (string)reader["ProductName"]
                        };

                        infoOrders.Add(od);
                    }
                }
            }

            return infoOrders;
        }

        public void CreateNewOrder(string custmerID, int employeeID, DateTime orderDate, DateTime requiueredDate, DateTime? shippedDate, int shipVia, double freight, string shipName, string shipAdress, string shipCity, string shipRegion, int shipPostalCode, string shipCountry)
        {
            using (IDbConnection connection = new SqlConnection(this.connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText =
                    @"INSERT INTO Northwind.Orders(
                                CustomerID
                               ,EmployeeID
                               ,OrderDate
                               ,RequiredDate
                               ,ShippedDate
                               ,ShipVia
                               ,Freight
                               ,ShipName
                               ,ShipAddress
                               ,ShipCity
                               ,ShipRegion
                               ,ShipPostalCode
                               ,ShipCountry)
                        values(
                                @CustomerID
                               ,@EmployeeID
                               ,@OrderDate
                               ,@RequiredDate
                               ,@ShippedDate
                               ,@ShipVia
                               ,@Freight
                               ,@ShipName
                               ,@ShipAddress
                               ,@ShipCity
                               ,@ShipRegion
                               ,@ShipPostalCode
                               ,@ShipCountry)";

                this.Parameter(command, "@CustomerID", custmerID, DbType.String);
                this.Parameter(command, "@EmployeeID", employeeID, DbType.Int32);
                this.Parameter(command, "@OrderDate", orderDate, DbType.DateTime);
                this.Parameter(command, "@RequiredDate", requiueredDate, DbType.DateTime);
                this.Parameter(command, "@ShippedDate", shippedDate, DbType.DateTime);
                this.Parameter(command, "@ShipVia", shipVia, DbType.Int32);
                this.Parameter(command, "@Freight", freight, DbType.Decimal);
                this.Parameter(command, "@ShipName", shipName, DbType.String);
                this.Parameter(command, "@ShipAddress", shipAdress, DbType.String);
                this.Parameter(command, "@ShipCity", shipCity, DbType.String);
                this.Parameter(command, "@ShipRegion", shipRegion, DbType.String);
                this.Parameter(command, "@ShipPostalCode", shipPostalCode, DbType.String);
                this.Parameter(command, "@ShipCountry", shipCountry, DbType.String);

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
