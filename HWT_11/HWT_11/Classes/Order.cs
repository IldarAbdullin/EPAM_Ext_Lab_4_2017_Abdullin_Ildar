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
        private DateTime? shippedDate;

        public Order()
        {
        }

        public Order(int orderID, string customerID, int employeeID, DateTime? orderDate, DateTime? shippedDate, string adress)
        {
            this.OrderID = orderID;
            this.CustomerID = customerID;
            this.EmployeeID = employeeID;
            this.OrderDate = orderDate;
            this.ShippedDate = shippedDate;
            this.ShipAddress = adress;
        }

        public int OrderID { get; set; }

        public string CustomerID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? ShippedDate
        {
            /// не понял че здесь ругается stylecope
            get { return this.shippedDate; }

            set
            {
                this.shippedDate = (DateTime?)value;
                this.Status = this.ShippedDate != null ? OrderStatus.Delivered : OrderStatus.NotShipped;
            }
        }

        public OrderStatus Status { get; set; }

        public string ShipAddress { get; set; }
    }
}