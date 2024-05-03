using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class ShipMethod
    {
        [Key]
        public int shipMethodId { get; set; }
        public string? shipMethodCode { get; set; }
        public string? shipMethodName { get; set; }
        public int price { get; set; }
    }
}
