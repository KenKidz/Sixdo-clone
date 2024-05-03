using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class ProductImg
    {
        [Key]
        public int productImgId { get; set; }
        public int productId { get; set; }
        public int? countImg { get; set; }
        public byte[]? productImg { get; set; }
        public Product? product { get; set; }
    }
}
