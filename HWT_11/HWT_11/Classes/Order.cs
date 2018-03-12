namespace HWT_11
{
    using System;

    public enum OrderStatus
    {
        Delivered,
        NotShipped
    }
    public class Order
    {
        private DateTime shippedDate;
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate
        {
            get { return shippedDate; }
            set
            {
                shippedDate = value;
                Status = ShippedDate != null ? OrderStatus.Delivered : OrderStatus.NotShipped;
            }
        }
        public OrderStatus Status { get; set; }
        public string ShipAddress { get; set; }
        public Order(int orderID, string customerID, int employeeID, DateTime orderDate, DateTime shippedDate, string adress)
        {
            this.OrderID = orderID;
            this.CustomerID = customerID;
            this.EmployeeID = employeeID;
            this.OrderDate = orderDate;
            this.ShippedDate = shippedDate;
            this.ShipAddress = adress;
        }
    }
}