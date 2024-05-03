using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class BillDetail
    {
        [Key]
        public int billDetailId { get; set; }
        public int? billId { get; set; }
        public int? productId { get; set; }
        public int? quantity { get; set; }
        public double price { get; set; }
        public Bill? bill { get; set; }
        public Product? product { get; set; }
    }
}
