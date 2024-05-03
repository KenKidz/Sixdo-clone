using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class AccountShipContact
    {
        [Key]
        public int accountShipContactId { get; set; }
        public int? accountId { get; set; }
        public string? receiverName { get; set; }
        public string? accountDetailAddress { get; set; }
        public string? accountPhoneNumber { get; set; }
        public int? accountShipContactStatusId { get; set; }
        public string? districtID { get; set; }
        public string? provinceID { get; set; }
        public string? wardCode { get; set; }
        public Accounts? account { get; set; }
        public AccountShipContactStatus? accountShipContactStatus { get; set; }
        public List<Bill>? bills { get; set; }
    }
}
