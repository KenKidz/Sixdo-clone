namespace ClothShop.Entities.adminres
{
    public class PrintBillData
    {
        public double? total { get; set; }
        public double? totalResult { get; set; }
        public double? shipPrice { get; set; }
        private double? _freeShip = 0d;
        private double _voucher = 0d;
        public double? freeShip
        {
            get { return _freeShip; }
            set { _freeShip = value; }
        }
        public double voucher
        {
            get { return _voucher; }
            set { _voucher = value; }
        }
        public string? billCode { get; set; }
        public string? reveceiName { get; set; }
        public string? reveceiSdt { get; set; }
        public string? reveceiAddress { get; set; }
        public string? employeeName { get; set; }
        public DateTime? closeDate { get; set; }
        public List<BillDetailPrint> billDetailPrints { get; set; }
    }
}
