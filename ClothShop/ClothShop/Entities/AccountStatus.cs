using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class AccountStatus
    {
        [Key]
        public int accountStatusId { get; set; }
        public string? accountStatusCode { get; set; }
        public string? accountStatusDetail { get; set; }
        public List<Accounts>? accounts { get; set; }
    }
}
