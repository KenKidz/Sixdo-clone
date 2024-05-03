using ClothShop.Entities;
using ClothShop.Entities.requestobject;
using ClothShop.Entities.responsobject;
using ClothShop.Helpers;

namespace ClothShop.IServices
{
    public interface IAppService
    {
        public List<Product> getProductHome();
        public CreateAccountData CreateAccount(CreateAccountData accountData);
        public AccountCustom CheckLogin(string userName, string userPass);
        public AccountCustom GetContact(int accountId);
        public AccountShipContact AddAccountShipContact(AccountShipContact accountShipContact);
        public AccountShipContact RemoveAccountShipContact(int idAccountShipContact);
        public AccountRemakeInfo RemakeAccountInfo(AccountRemakeInfo accountRemakeInfo);
        public RemakePassRes RemakePassword(RemakePassReq remakePassReq);
        public List<OrderRes> GetBillDetailByAccountId(int accountId);
        public Pagination<Product> nextPage(int page, int? filter);
        public ProductDetail GetProductId(int id);
        public AccountBag AddProduct2Bag(int accountId, int productId, int quantity);
        public List<ShowAccountBag> GetProductBagByAccountID(int accountId);
        public AccountBag updateAccountBag(int[] accountBagData);
        public AccountBag deleteAccountBag(int accountBagId);
        public CreateOrder GetCalCulBag(int[] listIdAccountBag);
        public OrderData createBill(OrderData orderData);
        public List<Product> searchProduct(string search);
        public Bill cancelBill(int billId, int type);
    }
}
