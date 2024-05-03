namespace ClothShop.Entities.requestobject
{
    public class RemakePassReq
    {
        public int accountId { get; set; }
        public string newPass { get; set; }
        public string oldPass { get; set; }
    }
}
