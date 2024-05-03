using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class Brand
    {
        [Key]
        public int brandId { get; set; }
        public string? brandCode { get; set; }
        public string? brandDetail { get; set; }
        /*public List IEnumerable<Product>? products { get; set; }*/
    }
}
