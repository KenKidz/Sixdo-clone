using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class ProductStatus
    {
        [Key]
        public int productStatusId { get; set; }
        public string? productStatusCode { get; set; }
        public string? productStatusDetail { get; set; }
    }
}
