namespace HWT_11
{
    public class CustOrderHist
    {
        public string ProductName { get; set; }
        public int Total { get; set; }

        public CustOrderHist(string ProductName, int Total)
        {
            this.ProductName = ProductName;
            this.Total = Total;
        }
    }
}