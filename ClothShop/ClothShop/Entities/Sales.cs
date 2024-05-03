using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class Sales
    {
        [Key]
        public int salesId { get; set; }
        public string? salesCode { get; set; }
        public string? salesName { get; set; }
        public int? salesPercent { get; set; }
        public int? salesInt { get; set; }
        public DateTime? openDate { get; set; }
        public DateTime? endDate { get; set; }
        public int? salessStatusId { get; set; }
        public int? saleTypeId { get; set; }
        public SalesStatus? salesStatus { get; set; }
        public SaleType? saleType { get; set; }
        public List<BillSales>? billSalesList { get; set; }
    }
}
