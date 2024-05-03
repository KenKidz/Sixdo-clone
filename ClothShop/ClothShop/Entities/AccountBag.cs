using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class AccountBag
    {
        [Key]
        public int accountBagId { get; set; }
        public int? accountId { get; set; }
        public int? productId { get; set; }
        public int? quantity { get; set; }
        public Accounts? account { get; set; }
        public Product? product { get; set; }
    }
}
