namespace ClothShop.Entities.adminres
{
    public class MonthAnalysis
    {
        public int shippedBillTotal { get; set; }
        public int soldTotal { get; set; }
        public double? profitBefore { get; set; }
        public int backBillTotal { get; set; }
        public double? shipLossTotal { get; set; }
        public double? resultProfit { get; set; }
    }
}
