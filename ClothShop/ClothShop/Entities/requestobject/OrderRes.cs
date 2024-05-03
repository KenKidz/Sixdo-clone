namespace ClothShop.Entities.requestobject
{
    public class OrderRes
    {
        public Bill bill { get; set; }
        public BillStatus billStatus { get; set; }
        public ShipMethod shipMethod { get; set; }
        public BuyMethod buyMethod { get; set; }
        public int? voucherSIXDO { get; set; }
        public int? freeShip { get; set; }
        public List<ProductBillDetail> productBillDetail { get; set; }
        public AccountShipContact accountShipContact { get; set; }
    }
}
