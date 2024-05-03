using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class BuyMethod
    {
        [Key]
        public int buyMethodId { get; set; }
        public string? buyMethodCode { get; set; }
        public string? buyMethodName { get; set; }
    }
}
