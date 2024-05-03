using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class Producer
    {
        [Key]
        public int producerId { get; set; }
        public string? producerCode { get; set; }
        public string? producerDetail { get; set; }
        /*public virtual IEnumerable<Product>? products { get; set; }*/
    }
}
