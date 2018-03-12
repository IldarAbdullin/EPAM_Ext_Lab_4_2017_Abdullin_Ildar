namespace HWT_11
{
    public class CustOrderHist
    {
        public CustOrderHist(string productName, int total)
        {
            this.ProductName = productName;
            this.Total = total;
        }

        public string ProductName { get; set; }

        public int Total { get; set; }      
    }
}