namespace ClothShop.Entities.adminres
{
    public class BillByType
    {
        public int billId { get; set; }
        public string? billCode { get; set; }
        public int idCustomer { get; set; }
        public string? customerName { get; set; }
        public string? reveceiMethod { get; set; }
        public string? reveceiName { get; set; }
        public string? reveceiSdt { get; set; }
        public string? voucherCode { get; set; }
        public string? voucherShipCode { get; set; }
        public DateTime? createBill { get; set; }
        public string? shipMethodName { get; set; }
        public double shipPrice { get; set; }
        public string? notification { get; set; }
        public DateTime? closeDate { get; set; }
        public DateTime? reveceiDate { get; set; }
        public string? billStatus { get; set; }
        public string? buyMethod { get; set; }
        public string? buyStatus { get; set; }
        public string? reveceiContact { get; set; }
        public string? shipStatus { get; set; }
        public double totalBill { get; set; }
        public int? shipVoucher { get; set; }
        public int? voucherVoucher { get; set; }
        public double totalResult { get; set; }
        public int? billStatusId { get; set; }
        public List<BillDetailAnalysis> billDetailAnalyses { get; set; }
    }
}
