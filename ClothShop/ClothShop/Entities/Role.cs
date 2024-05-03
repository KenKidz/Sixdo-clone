using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class Role
    {
        [Key]
        public int roleID { get; set; }
        public string? roleCode { get; set; }
        public string? roleDetail { get; set; }
        public List<Accounts>? accounts { get; set; }
    }
}
