namespace HWT_11
{
    using System;

    public class OrderDetails : Order
    {
        public OrderDetails(int orderID, string customerID, int employeeID, DateTime orderDate, DateTime shippedDate, string adress, int productID, string productName, short quality, double price, double discont) : base(orderID, customerID, employeeID, orderDate, shippedDate, adress)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Quantity = quality;
            this.UnityPrice = price;
            this.Discont = discont;
        }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public short Quantity { get; set; }

        public double UnityPrice { get; set; }

        public double Discont { get; set; }
    }
}