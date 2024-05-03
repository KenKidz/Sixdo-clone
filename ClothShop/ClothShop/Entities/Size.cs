using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class Size
    {
        [Key]
        public int sizeId { get; set; }
        public string? sizeCode { get; set; }
        public string? sizeDetail { get; set; }
        /*public virtual IEnumerable<Product>? products { get; set; }*/
    }
}
