using AutoMapper;
using ClothShop.DAO;
using ClothShop.Entities;
using ClothShop.Entities.adminreq;
using ClothShop.Entities.adminres;
using ClothShop.IServices;
using ClothShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClothShop.Controllers
{
    [Route("api/admin1.0")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;


        public AdminController(AppDbContext dbContext, IMapper mapper)
        {
            _adminService = new AdminService(dbContext, mapper);
        }

        [HttpGet("getanalysisshop")]
        public async Task<IActionResult> GetAnalysisData()
        {
            var result = await _adminService.GetAnalysisData();
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("getallproperty")]
        public IActionResult GetAllProperty()
        {
            return Ok(_adminService.GetAllProperty());
        }

        [HttpPost("upload")]
        public void addProduct(IFormFile file1, IFormFile file2, [FromForm] string data)
        {
            /*var options = new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString |
                 JsonNumberHandling.WriteAsString
            };*/
            var myObj = JsonSerializer.Deserialize<CreateProductData>(data, new JsonSerializerOptions());
            _adminService.addProduct(file1, file2, myObj);
        }

        [HttpGet("searchtop5product")]
        [Produces("application/json")]
        public List<Product> searchProduct(string search)
        {
            return _adminService.searchProduct(search);
        }

        [HttpPost("remakeproduct")]
        /*[Produces("application/json")]*/
        public IActionResult RemakeProduct(Product p)
        {
            /*var myObj = JsonSerializer.Deserialize<Product>(data, new JsonSerializerOptions());*/
            return Ok(_adminService.RemakeProduct(p));
        }

        [HttpPost("createproperty")]
        public IActionResult CreateProperty(CreateAndRemakePropertyData cr)
        {
            return Ok(_adminService.CreateProperty(cr));
        }

        [HttpPut("remakeproperty")]
        public IActionResult RemakeProperty(CreateAndRemakePropertyData cr)
        {
            return Ok(_adminService.remakeProperty(cr));
        }

        [HttpGet("sales")]
        public IActionResult getAllSales()
        {
            return Ok(_adminService.getAllSales());
        }

        [HttpPost("createsales")]
        public void createVoucher(Sales data)
        {
            _adminService.createVoucher(data);
        }

        [HttpGet("getallbilltype")]
        public List<BillByType> GetAllBillByType(int opt)
        {
            return _adminService.getAllBillByType(opt);
        }

        [HttpPut("adminsetbill")]
        public void adminSetBill(int opt, int idBill, int idEmployee)
        {
            _adminService.adminSetBill(opt, idBill, idEmployee);
        }

        [HttpGet("printbill")]
        public IActionResult PrintBill(int idBill)
        {
            return Ok(_adminService.printBill(idBill));
        }

        [HttpPost("createbillinshop")]
        public IActionResult CreateBillInShop(int idEmployee)
        {
            return Ok(_adminService.createBillInShop(idEmployee));
        }

        [HttpGet("getallbilldetailofbill")]
        public IActionResult GetAllBillDetailOfBill(int idBill)
        {
            return Ok(_adminService.getAllBillDetailOfBill(idBill));
        }

        [HttpGet("addproduct2billdetail")]
        public void AddProduct2BillDetail(int idProduct, int idBill)
        {
            _adminService.addProduct2BillDetail(idProduct, idBill);
        }

        [HttpGet("deletebilldetail2")]
        public void DeleteBillDetail(int idBillDetail)
        {
            _adminService.deleteBillDetail(idBillDetail);
        }

        [HttpGet("updatebilldetailquantity")]
        public void UpdateQuantityBillDetail(int idBillDetail, int quantity)
        {
            _adminService.updateQuantityBillDetail(idBillDetail, quantity);
        }

        [HttpPost("getpaybillrequest")]
        public void payHoldBill(HoldBillRequestPayBill holdBillRequestPayBill)
        {
            _adminService.payHoldBill(holdBillRequestPayBill);
        }

        [HttpGet("getallholdingbill")]
        public List<Bill> getAllHoldingBill()
        {
            return _adminService.getAllHoldingBill();
        }
    }
}
