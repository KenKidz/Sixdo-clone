using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class Accounts
    {
        [Key]
        public int accountId { get; set; }
        public string? accountUserName { get; set; }
        public string? accountPassword { get; set; }
        public int? accountStatusId { get; set; }
        public string? accountName { get; set; }
        public DateTime? accountBorn { get; set; }
        public string? accountDetailAddress { get; set; }
        public DateTime? accountCreateDate { get; set; }
        public int? roleID { get; set; }
        public DateTime? createDate { get; set; }
        public DateTime? updateDate { get; set; }
        public string? sdt { get; set; }
        public List<AccountShipContact>? accountShipContacts { get; set; }
        public List<AccountBag>? accountBags { get; set; }
        public AccountStatus? accountStatus { get; set; }
        public Role? role { get; set; }
    }
}
