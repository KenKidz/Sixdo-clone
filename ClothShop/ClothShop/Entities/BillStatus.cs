using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class BillStatus
    {
        [Key]
        public int billStatusId { get; set; }
        public string? billStatusCode { get; set; }
        public string? billStatusDetail { get; set; }
        public List<Bill>? bills { get; set; }
    }
}
