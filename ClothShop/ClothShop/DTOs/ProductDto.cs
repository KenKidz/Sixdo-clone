using ClothShop.Entities;

namespace ClothShop.DTOs
{
    public class ProductDto
    {
        public int productId { get; set; }
        public string? productName { get; set; }
        public string? productDetail { get; set; }
        public int? categoryTypeId { get; set; }
        public int? sizeId { get; set; }
        public int? colorId { get; set; }
        public int? brandId { get; set; }
        public int? producerId { get; set; }
        public int? quantity { get; set; }
        public int? price { get; set; }
        public int? shellPrice { get; set; }
        public DateTime? createDate { get; set; }
        public DateTime? updateDate { get; set; }
        public int? productStatusId { get; set; }
        public List<ProductImgDto> ProductImgs { get; set; }
    }
}
