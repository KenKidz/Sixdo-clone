using ClothShop.DAO;
using ClothShop.Entities;
using ClothShop.Entities.requestobject;
using ClothShop.Entities.responsobject;
using ClothShop.Helpers;
using ClothShop.IServices;
using ClothShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClothShop.Controllers
{
    [Route("api/product1.0")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly IAppService _appService;
        public AppController(AppDbContext dbContext)
        {
            _appService = new AppService(dbContext);
        }
        [HttpGet("getproducthome")]
        public List<Product> GetProductHome()
        {
            var dsProductHome = _appService.getProductHome();
            return dsProductHome;
        }

        [HttpGet("search")]
        public List<Product> SearchProduct(string search)
        {
            return _appService.searchProduct(search);
        }
        [HttpGet("nextpage")]
        public Pagination<Product> nextPage(int page, int? filter)
        {
            return _appService.nextPage(page, filter);
        }

        [HttpGet("getproductid")]
        public IActionResult GetProductId(int id)
        {
            return Ok(_appService.GetProductId(id));
        }

        [HttpPost("addproduct2bag")]
        public IActionResult AddProduct2Bag(int accountId, int productId, int quantity)
        {
            return Ok(_appService.AddProduct2Bag(accountId, productId, quantity));
        }

        [HttpGet("getproductbagbyaccountid")]
        public List<ShowAccountBag> GetProductBagByAccountID(int accountId)
        {
            return _appService.GetProductBagByAccountID(accountId);
        }

        [HttpPut("updateaccountbagbyid")]
        public IActionResult updateAccountBag(int[] accountBagData)
        {
            return Ok(_appService.updateAccountBag(accountBagData));
        }

        [HttpDelete("deleteaccountbag")]
        public IActionResult deleteAccountBag(int accountBagId)
        {
            return Ok(_appService.deleteAccountBag(accountBagId));
        }

        [HttpPost("getcalculbag")]
        public IActionResult GetCalCulBag(int[] listIdAccountBag)
        {
            return Ok(_appService.GetCalCulBag(listIdAccountBag));
        }
        /*[HttpGet("nextpage")]
        public List<Product> nextPage(int page)
        {
            return _appService.nextPage(page);
        }*/

        [HttpPost("createaccount")]
        public IActionResult CreateAccount(CreateAccountData accountData)
        {
            return Ok(_appService.CreateAccount(accountData));
        }
        [HttpGet("checklogin")]
        public IActionResult CheckLogin(string userName, string userPass)
        {
            var res = _appService.CheckLogin(userName, userPass);
            return Ok(res);
        }
        [HttpGet("getcontacts")]
        public IActionResult GetContact(int accountId)
        {
            var res1 = _appService.GetContact(accountId);
            return Ok(res1);
        }
        [HttpPost("addnewaccountshipcontact")]
        public IActionResult AddAccountShipContact(AccountShipContact accountShipContact)
        {
            var res2 = _appService.AddAccountShipContact(accountShipContact);
            return Ok(res2);
        }
        [HttpPut("deleteshipcontact")]
        public IActionResult RemoveAccShipContact(int idAccountShipContact)
        {
            var res3 = _appService.RemoveAccountShipContact(idAccountShipContact);
            return Ok(res3);
        }
        [HttpPut("remakeaccount")]
        public IActionResult RemakeAccountInfo(AccountRemakeInfo accountRemakeInfo)
        {
            return Ok(_appService.RemakeAccountInfo(accountRemakeInfo));
        }
        [HttpPut("remakepassword")]
        public IActionResult RemakePassword(RemakePassReq remakePassReq)
        {
            return Ok(_appService.RemakePassword(remakePassReq));
        }
        [HttpGet("getbilldetailbyaccountid")]
        public List<OrderRes> GetBillDetailByAccountId(int accountId)
        {
            return _appService.GetBillDetailByAccountId(accountId);
        }

        [HttpPost("createbill")]
        public IActionResult CreateBill(OrderData orderData)
        {
            return Ok(_appService.createBill(orderData));
        }
        [HttpPut("cancelbill")]
        public IActionResult CancelBill(int billId, int type)
        {
            return Ok(_appService.cancelBill(billId, type));
        }
    }
}
