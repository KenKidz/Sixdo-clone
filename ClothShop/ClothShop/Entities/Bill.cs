using System.ComponentModel.DataAnnotations;

namespace ClothShop.Entities
{
    public class Bill
    {
        [Key]
        public int billId { get; set; }
        public int? accountShipContactId { get; set; }
        public int? buyMethodId { get; set; }
        public DateTime createDate { get; set; }
        public DateTime? shipToBuyerDate { get; set; }
        public DateTime? receivedDate { get; set; }
        public DateTime? closeDate { get; set; }
        public int? billStatusId { get; set; }
        public double totalBill { get; set; }
        public DateTime? productReturnDate { get; set; }
        public string? buyerNotification { get; set; }
        public int? shipMethodId { get; set; }
        public double shipPrice { get; set; }
        public string? billCode { get; set; }
        public int? idEmployee { get; set; }
        public Accounts? employee { get; set; }
        public AccountShipContact? accountShipContact { get; set; }
        public BuyMethod? buyMethod { get; set; }
        public BillStatus? billStatus { get; set; }
        public ShipMethod? shipMethod { get; set; }
        public List<BillSales>? billSalesList { get; set; }
        public List<BillDetail>? billDetails { get; set; }
    }
}
