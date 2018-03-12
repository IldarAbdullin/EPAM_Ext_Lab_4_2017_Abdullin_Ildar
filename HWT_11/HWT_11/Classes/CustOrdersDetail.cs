namespace HWT_11
{
    public class CustOrdersDetail
    {
        public CustOrdersDetail(string productName, decimal unitPrice, int quantity, int discount, decimal extendedPrice)
        {
            this.ProductName = productName;
            this.UnitPrice = unitPrice;
            this.Quantity = quantity;
            this.Discount = discount;
            this.ExtendedPrice = extendedPrice;
        }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        public int Discount { get; set; }

        public decimal ExtendedPrice { get; set; }
    }
}