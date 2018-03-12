namespace HWT_11
{
    public class CustOrdersDetail
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public decimal ExtendedPrice { get; set; }

        public CustOrdersDetail(string ProductName, decimal UnitPrice, int Quantity, int Discount, decimal ExtendedPrice)
        {
            this.ProductName = ProductName;
            this.UnitPrice = UnitPrice;
            this.Quantity = Quantity;
            this.Discount = Discount;
            this.ExtendedPrice = ExtendedPrice;
        }
    }
}