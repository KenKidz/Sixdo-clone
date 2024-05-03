namespace ClothShop.Entities.adminres
{
    public class HoldBill
    {
        public List<BillDetailAndProduct> billDetailAndProductList;
        public Bill bill { get; set; }
        public List<Sales> sales { get; set; }
    }
}
