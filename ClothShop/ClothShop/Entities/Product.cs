using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ClothShop.Entities
{
    public class Product
    {
        [Key]
        public int productId { get; set; }
        public string? productName { get; set; }
        public string? productDetail { get; set; }
        public int? categoryTypeId { get; set; }
        public int? sizeId { get; set; }
        public int? colorId { get; set; }
        public int? brandId { get; set; }
        public int? producerId { get; set; }
        public int? quantity { get; set; }
        public int price { get; set; }
        public int shellPrice { get; set; }
        public DateTime? createDate { get; set; }
        public DateTime? updateDate { get; set; }
        public int productStatusId { get; set; }
        public CategoryType? categoryType { get; set; }
        public Size? size { get; set; }
        public Color? color { get; set; }
        public Brand? brand { get; set; }
        public Producer? producer { get; set; }
        public ProductStatus? productStatus { get; set; }
        public List<BillDetail>? billDetails { get; set; }
        public List<ProductImg>? productImgs { get; set; }
    }
}
