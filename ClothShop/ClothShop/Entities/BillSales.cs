using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class BillSales
    {
        [Key]
        public int billSalesId { get; set; }
        public int? salesId { get; set; }
        public int? billId { get; set; }
        public Bill? bill { get; set; }
        public Sales? sales { get; set; }
    }
}
