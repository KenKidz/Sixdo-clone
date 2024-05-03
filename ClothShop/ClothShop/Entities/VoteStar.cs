using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class VoteStar
    {
        [Key]
        public int voteStarId { get; set; }
        public int? productId { get; set; }
        public int? accountId { get; set; }
        public int starVoted { get; set; }
        public Product? product { get; set; }
        public Accounts? account { get; set; }
    }
}
