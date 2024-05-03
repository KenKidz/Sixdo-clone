namespace ClothShop.Entities.adminres
{
    public class BillDetailAndProduct
    {
        public BillDetail billDetail { get; set; }
        public Product product { get; set; }
        public DateTime? createDate { get; set; }
    }
}
