namespace ClothShop.Entities.requestobject
{
    public class OrderData
    {
        public int accountShipContactId { get; set; }
        public List<int>? accountBags { get; set; }
        public int shipOptId { get; set; }
        public int buyOptId { get; set; }
        public int? shipVoucher { get; set; }
        public int? voucherVoucher { get; set; }
        public string? buyerNotification { get; set; }
        public double shipPrice { get; set; }
    }
}
