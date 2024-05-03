using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class Color
    {
        [Key]
        public int colorId { get; set; }
        public string? colorCode { get; set; }
        public string? colorDetail { get; set; }
        /*public List<Product>? products { get; set; }*/
    }
}
