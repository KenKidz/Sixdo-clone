namespace ClothShop.Entities.responsobject
{
    public class AccountCustom
    {
        public int? Id { get; set; }
        public string? name { get; set; }
        public string? address { get; set; }
        public DateTime? born { get; set; }
        public List<AccountShipContact>? shipContacts { get; set; }
        public int? roleID { get; set; }
        public string? sdt { get; set; }
        public int status { get; set; }
    }
}
