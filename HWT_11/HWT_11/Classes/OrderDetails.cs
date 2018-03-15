namespace HWT_11
{
    using System;

    public class OrderDetails : Order
    {
        public OrderDetails()
        {
        }

        public OrderDetails(int orderID, string customerID, int employeeID, DateTime orderDate, DateTime shippedDate, string adress, int productID, string productName, short quality, decimal price, double discont) : base(orderID, customerID, employeeID, orderDate, shippedDate, adress)
        {
            this.ProductID = productID;
            this.ProductName = productName;
            this.Quantity = quality;
            this.UnitPrice = price;
            this.Discount = discont;
        }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public double Discount { get; set; }
    }
}