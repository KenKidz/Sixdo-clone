using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class SalesStatus
    {
        [Key]
        public int salessStatusId { get; set; }
        public string? statusCode { get; set; }
        public string? statusDetail { get; set; }
        public List<Sales>? saless { get; set; }
    }
}
