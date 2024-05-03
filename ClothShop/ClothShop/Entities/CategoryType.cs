using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ClothShop.Entities
{
    public class CategoryType
    {
        [Key]
        public int categoryTypeId { get; set; }
        public string? categoryTypeCode { get; set; }
        public string? categoryTypeDetail { get; set; }
        public List<Product>? products { get; set; }
    }
}
