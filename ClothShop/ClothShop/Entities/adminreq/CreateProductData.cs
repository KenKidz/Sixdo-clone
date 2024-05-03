using System.Text.Json.Serialization;

namespace ClothShop.Entities.adminreq
{
    public class CreateProductData
    {
        public string? productName { get; set; }
        public string? productDetail { get; set; }
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString |
        JsonNumberHandling.WriteAsString)]
        public int productPrice { get; set; }
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString |
        JsonNumberHandling.WriteAsString)]
        public int productShellPrice { get; set; }
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString |
        JsonNumberHandling.WriteAsString)]
        public int productQuantity { get; set; }
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString |
        JsonNumberHandling.WriteAsString)]
        public int color { get; set; }
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString |
        JsonNumberHandling.WriteAsString)]
        public int brand { get; set; }
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString |
        JsonNumberHandling.WriteAsString)]
        public int producer { get; set; }
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString |
        JsonNumberHandling.WriteAsString)]
        public int size { get; set; }
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString |
        JsonNumberHandling.WriteAsString)]
        public int category { get; set; }
    }
}
