using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class AccountShipContactStatus
    {
        [Key]
        public int accountShipContactStatusId { get; set; }
        public string? accountShipContactStatusCode { get; set; }
        public string? accountShipContactStatusDetail { get; set; }
        public virtual IEnumerable<AccountShipContact>? accountShipContacts { get; set; }
    }
}
