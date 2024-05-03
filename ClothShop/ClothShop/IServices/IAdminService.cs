using ClothShop.Entities;
using ClothShop.Entities.adminreq;
using ClothShop.Entities.adminres;

namespace ClothShop.IServices
{
    public interface IAdminService
    {
        public PropertyRes GetAllProperty();
        public void addProduct(IFormFile file1, IFormFile file2, CreateProductData data);
        public List<Product> searchProduct(string search);
        public Product RemakeProduct(Product p);
        public CreateAndRemakePropertyData CreateProperty(CreateAndRemakePropertyData cr);
        public CreateAndRemakePropertyData remakeProperty(CreateAndRemakePropertyData cr);
        public SalesObject getAllSales();
        public void createVoucher(Sales data);
        public List<BillByType> getAllBillByType(int type);
        public void adminSetBill(int opt, int billId, int idEmployee);
        public PrintBillData printBill(int idBill);
        public Bill createBillInShop(int idEmployee);
        public HoldBill getAllBillDetailOfBill(int idBill);
        public void addProduct2BillDetail(int idProduct, int idBill);
        public void deleteBillDetail(int idBillDetail);
        public void updateQuantityBillDetail(int idBillDetail, int quantity);
        public void payHoldBill(HoldBillRequestPayBill holdBillRequestPayBill);
        public List<Bill> getAllHoldingBill();
        Task<Analysis> GetAnalysisData();
    }
}
