namespace ClothShop.DTOs
{
    public class ProductImgDto
    {
        public int productImgId { get; set; }
        public int? productId { get; set; }
        public int? counting { get; set; }
        public byte[]? productImg { get; set; }
    }
}
