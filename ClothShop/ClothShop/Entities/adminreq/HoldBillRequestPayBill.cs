namespace ClothShop.Entities.adminreq
{
    public class HoldBillRequestPayBill
    {
        public int idBill { get; set; }
        public int idEmployee { get; set; }
        public int idVoucher { get; set; }
        public int idBuyMethod { get; set; }
        public string? customerName { get; set; }
        public string? customerSdt { get; set; }
        public string? customAddress { get; set; }
    }
}
