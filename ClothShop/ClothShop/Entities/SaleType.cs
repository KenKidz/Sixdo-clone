using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class SaleType
    {
        [Key]
        public int saleTypeId { get; set; }
        public string? saleTypeCode { get; set; }
        public string? saleTypeDetail { get; set; }
    }
}
