using AutoMapper;
using ClothShop.DAO;
using ClothShop.DTOs;
using ClothShop.Entities;
using ClothShop.Entities.adminreq;
using ClothShop.Entities.adminres;
using ClothShop.Helpers;
using ClothShop.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Security.Cryptography.Xml;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace ClothShop.Services
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AdminService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public PropertyRes GetAllProperty()
        {
            PropertyRes property = new PropertyRes();
            property.brands = _dbContext.Brands.ToList();
            property.colors = _dbContext.Colors.ToList();
            property.producers = _dbContext.Producers.ToList();
            property.sizes = _dbContext.Sizes.ToList();
            property.categoryTypes = _dbContext.CategoryTypes.ToList();
            property.productStatuses = _dbContext.ProductStatuses.ToList();
            return property;
        }

        public static byte[] ConvertIFormFileToByteArray(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public void addProduct(IFormFile file1, IFormFile file2, CreateProductData data)
        {
            try
            {
                Product p = new Product();
                /*var newProduct = _mapper.Map<Product>(p);*/
                p.quantity = data.productQuantity;
                p.productName = data.productName;
                p.productDetail = data.productDetail;
                p.createDate = DateTime.Now;
                p.categoryTypeId = data.category;
                p.colorId = data.color;
                p.brandId = data.brand;
                p.producerId = data.producer;
                p.sizeId = data.size;
                p.price = data.productPrice;
                p.shellPrice = data.productShellPrice;
                p.productStatusId = 1;
                _dbContext.Products.Add(p);
                _dbContext.SaveChanges();

                ProductImg pi1 = new ProductImg();
                pi1.productId = p.productId;
                pi1.countImg = 1;
                if (file1 != null)
                {
                    string extension = Path.GetExtension(file1.FileName);
                    /*string image = Utilities.SEOUrl(p.productName) + extension;*/
                    pi1.productImg = Utilities.UploadFile(file1, @"productImg", file1.FileName.ToLower());
                    _dbContext.ProductImgs.Add(pi1);
                    _dbContext.SaveChanges();
                }

                ProductImg pi2 = new ProductImg();
                pi2.productId = p.productId;
                pi2.countImg = 2;
                if (file2 != null)
                {
                    string extension2 = Path.GetExtension(file2.FileName);
                    /*string image2 = Utilities.SEOUrl(p.productName) + extension2;*/
                    pi2.productImg = Utilities.UploadFile(file2, @"productImg", file2.FileName.ToLower());
                    _dbContext.ProductImgs.Add(pi2);
                    _dbContext.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Product> searchProduct(string search)
        {
            return _dbContext.Products.Include(a => a.productImgs).Where(x => x.productDetail.Contains(search)).OrderBy(p => p.productId).Take(5).ToList();
        }

        public Product RemakeProduct(Product p)
        {
            var product = _dbContext.Products.Include(a => a.productImgs).FirstOrDefault(x => x.productId == p.productId);
            product.shellPrice = p.shellPrice;
            product.productDetail = p.productDetail;
            product.updateDate = DateTime.Now;
            product.productName = p.productName;
            product.categoryTypeId = p.categoryTypeId;
            product.quantity = p.quantity;
            product.colorId = p.colorId;
            product.brandId = p.brandId;
            product.productStatusId = p.productStatusId;
            product.sizeId = p.sizeId;
            product.producerId = p.producerId;
            _dbContext.Update(product);
            _dbContext.SaveChanges();
            return product;
        }

        public CreateAndRemakePropertyData CreateProperty(CreateAndRemakePropertyData cr)
        {
            switch (cr.type)
            {
                case 1:
                    var color = new Color();
                    color.colorCode = cr.code;
                    color.colorDetail = cr.detail;
                    _dbContext.Add(color);
                    _dbContext.SaveChanges();
                    break;
                case 2:
                    var producer = new Producer();
                    producer.producerCode = cr.code;
                    producer.producerDetail = cr.detail;
                    _dbContext.Add(producer);
                    _dbContext.SaveChanges();
                    break;
                case 4:
                    var size = new Size();
                    size.sizeCode = cr.code;
                    size.sizeDetail = cr.detail;
                    _dbContext.Add(size);
                    _dbContext.SaveChanges();
                    break;
                case 3:
                    var brand = new Brand();
                    brand.brandCode = cr.code;
                    brand.brandDetail = cr.detail;
                    _dbContext.Add(brand);
                    _dbContext.SaveChanges();
                    break;
                default:
                    break;
            }
            return cr;
        }

        public CreateAndRemakePropertyData remakeProperty(CreateAndRemakePropertyData cr)
        {
            switch (cr.type)
            {
                case 1:
                    var color = _dbContext.Colors.FirstOrDefault(x => x.colorId == cr.id);
                    color.colorCode = cr.code;
                    color.colorDetail = cr.detail;
                    _dbContext.Update(color);
                    _dbContext.SaveChanges();
                    break;
                case 2:
                    var producer = _dbContext.Producers.FirstOrDefault(x => x.producerId == cr.id);
                    producer.producerCode = cr.code;
                    producer.producerDetail = cr.detail;
                    _dbContext.Update(producer);
                    _dbContext.SaveChanges();
                    break;
                case 4:
                    var size = _dbContext.Sizes.FirstOrDefault(x => x.sizeId == cr.id);
                    size.sizeCode = cr.code;
                    size.sizeDetail = cr.detail;
                    _dbContext.Update(size);
                    _dbContext.SaveChanges();
                    break;
                case 3:
                    var brand = _dbContext.Brands.FirstOrDefault(x => x.brandId == cr.id);
                    brand.brandCode = cr.code;
                    brand.brandDetail = cr.detail;
                    _dbContext.Update(brand);
                    _dbContext.SaveChanges();
                    break;
                default:
                    break;
            }
            return cr;
        }

        public SalesObject getAllSales()
        {
            SalesObject so = new SalesObject();
            so.shipVouchers = _dbContext.Sales.Where(x => x.saleTypeId == 1).ToList();
            so.voucherVouchers = _dbContext.Sales.Where(x => x.saleTypeId == 2).ToList();
            return so;
        }

        public void createVoucher(Sales data)
        {
            data.salessStatusId = 1;
            /*data.salesType = _dbContext.SalesTypes.FirstOrDefault(x => x.salesTypeId == data.saleTypeId);*/
            _dbContext.Add(data);
            _dbContext.SaveChanges();
        }

        public List<BillByType> getAllBillByType(int type)
        {
            List<Bill> billList = new List<Bill>();
            if (type == 1)
            {
                billList = _dbContext.Bills.Include(x => x.billSalesList).ThenInclude(x => x.sales)
                    .Include(x => x.accountShipContact).ThenInclude(x => x.account)
                    .Include(x => x.shipMethod)
                    .Include(x => x.buyMethod)
                    .Include(x => x.billStatus)
                    .Include(x => x.billDetails).ThenInclude(x => x.product).ThenInclude(x => x.productImgs)
                    .Where(x => x.billStatusId == 1).ToList();
            }
            if (type == 2)
            {
                billList = _dbContext.Bills.Include(x => x.billSalesList).ThenInclude(x => x.sales)
                    .Include(x => x.accountShipContact).ThenInclude(x => x.account)
                    .Include(x => x.shipMethod)
                    .Include(x => x.billStatus)
                    .Include(x => x.buyMethod)
                    .Include(x => x.billDetails).ThenInclude(x => x.product).ThenInclude(x => x.productImgs)
                    .Where(x => x.billStatusId == 2).ToList();
            }
            if (type == 3)
            {
                billList = _dbContext.Bills.Include(x => x.billSalesList).ThenInclude(x => x.sales)
                    .Include(x => x.accountShipContact).ThenInclude(x => x.account)
                    .Include(x => x.shipMethod)
                    .Include(x => x.buyMethod)
                    .Include(x => x.billStatus)
                    .Include(x => x.billDetails).ThenInclude(x => x.product).ThenInclude(x => x.productImgs)
                    .Where(x => x.billStatusId == 3).ToList();
            }
            List<BillByType> billByTypes = new List<BillByType>();
            foreach (var bill in billList)
            {
                BillByType bt = new BillByType();
                if (bill.billSalesList != null)
                {
                    foreach (var s in bill.billSalesList)
                    {
                        if (s.sales.saleTypeId == 1)
                        {
                            bt.voucherShipCode = s.sales.salesCode;
                            bt.shipVoucher = s.sales.salesInt + s.sales.salesPercent;
                        }
                        if (s.sales.saleTypeId == 2)
                        {
                            bt.voucherCode = s.sales.salesCode;
                            bt.voucherVoucher = s.sales.salesInt + s.sales.salesPercent;
                        }
                    }
                }
                bt.billStatusId = bill.billStatusId;
                bt.buyStatus = "Chưa thanh toán";
                bt.shipStatus = "Đang giao";
                if (type == 3)
                {
                    bt.closeDate = bill.closeDate;
                    bt.reveceiDate = bill.receivedDate;
                    bt.buyStatus = "Đã thanh toán";
                    bt.shipStatus = "Đã nhận hàng";
                }
                if (type == 1)
                {
                    bt.shipStatus = "Đơn chờ";
                }
                if (bill.accountShipContact != null)
                {
                    bt.reveceiContact = bill.accountShipContact.accountDetailAddress;
                }
                if (bill.shipMethod != null)
                {
                    bt.reveceiMethod = bill.shipMethod.shipMethodName;
                }
                bt.buyMethod = bill.buyMethod.buyMethodName;
                bt.billStatus = bill.billStatus.billStatusDetail;
                bt.notification = bill.buyerNotification;
                bt.billId = bill.billId;
                bt.createBill = bill.createDate;
                bt.billCode = bill.billCode;
                if (bill.accountShipContact != null)
                {
                    bt.customerName = bill.accountShipContact.account.accountName;
                    bt.reveceiName = bill.accountShipContact.receiverName;
                    bt.reveceiSdt = bill.accountShipContact.accountPhoneNumber;
                    bt.idCustomer = bill.accountShipContact.account.accountId;
                }
                if (bill.shipMethod != null)
                {
                    bt.shipMethodName = bill.shipMethod.shipMethodName;
                }
                bt.shipPrice = bill.shipPrice;
                List<BillDetailAnalysis> bdList = new List<BillDetailAnalysis>();
                double? total = 0d;
                foreach (var bd in bill.billDetails)
                {
                    BillDetailAnalysis bda = new BillDetailAnalysis();
                    bda.billDetailId = bd.billDetailId;
                    bda.quantity = bd.quantity;
                    bda.quantityInventory = bd.product.quantity;
                    bda.productImg = bd.product.productImgs[0].productImg;
                    bda.productName = bd.product.productName;
                    bda.shellprice = bd.product.shellPrice;
                    bda.total = bda.shellprice * bda.quantity;
                    total += bda.total;
                    bdList.Add(bda);
                }
                bt.totalBill = (double)total;
                bt.billDetailAnalyses = bdList;
                billByTypes.Add(bt);
            }
            return billByTypes;
        }
        public void adminSetBill(int opt, int billId, int idEmployee)
        {
            if (opt == 1)
            {
                Bill bill = _dbContext.Bills.FirstOrDefault(x => x.billId == billId);
                bill.billStatusId = 6;
                bill.closeDate = DateTime.Now;
                bill.idEmployee = idEmployee;
                _dbContext.Update(bill);
                _dbContext.SaveChanges();
                return;
            }
            if (opt == 2)
            {
                Bill bill = _dbContext.Bills.Include(x => x.billDetails).FirstOrDefault(x => x.billId == billId);
                bill.billStatusId = 2;
                bill.idEmployee = idEmployee;
                bill.shipToBuyerDate = DateTime.Now.AddDays(5);
                foreach (var bd in bill.billDetails)
                {
                    Product p = _dbContext.Products.FirstOrDefault(x => x.productId == bd.productId);
                    p.quantity = p.quantity - bd.quantity;
                    _dbContext.Update(p);
                    _dbContext.SaveChanges();
                }
                _dbContext.Update(bill);
                return;
            }
        }
        public PrintBillData printBill(int idBill)
        {
            Bill bill = _dbContext.Bills.Include(x => x.accountShipContact)
                .Include(x => x.billDetails).ThenInclude(x => x.product)
                .FirstOrDefault(x => x.billId == idBill);
            PrintBillData printBillData = new PrintBillData();
            if (bill.accountShipContact != null)
            {
                printBillData.reveceiAddress = bill.accountShipContact.accountDetailAddress;
                printBillData.reveceiName = bill.accountShipContact.receiverName;
                printBillData.reveceiName = bill.accountShipContact.accountPhoneNumber;
            }
            if (bill.shipPrice != null)
            {
                printBillData.shipPrice = bill.shipPrice;
            }
            else
            {
                printBillData.shipPrice = 0d;
            }
            List<BillDetailPrint> billDetailPrints = new List<BillDetailPrint>();
            double? total = 0d;
            foreach (var bd in bill.billDetails)
            {
                BillDetailPrint bdp = new BillDetailPrint();
                bdp.price = bd.price;
                bdp.productName = bd.product.productDetail;
                bdp.quantity = bd.quantity;
                total += bd.quantity * bd.price;
                billDetailPrints.Add(bdp);
            }
            printBillData.total = total;
            printBillData.billDetailPrints = billDetailPrints;
            var a = _dbContext.Sales.Include(x => x.billSalesList).Where(c => c.billSalesList.Any(t => t.billId == bill.billId));
            foreach (var s in a)
            {
                if (s.saleTypeId == 1)
                {
                    printBillData.freeShip = (double)(s.salesInt + s.salesPercent);
                }
                if (s.saleTypeId == 2)
                {
                    printBillData.voucher = (double)(s.salesInt + s.salesPercent);
                }
            }
            double? totalResult = total;
            if (printBillData.freeShip != null)
            {
                if (printBillData.freeShip < 100)
                {
                    totalResult -= (printBillData.freeShip * total) / 100;
                }
                if (printBillData.freeShip > 100)
                {
                    totalResult -= printBillData.freeShip;
                }
            }

            if (printBillData.voucher != null)
            {
                if (printBillData.voucher < 100)
                {
                    totalResult -= (printBillData.voucher * total) / 100;
                }
                if (printBillData.voucher > 100)
                {
                    totalResult -= printBillData.voucher;
                }
            }
            printBillData.totalResult = totalResult;
            if (bill.shipPrice != null)
            {
                printBillData.totalResult = totalResult + bill.shipPrice;
            }
            printBillData.billCode = bill.billCode;
            printBillData.closeDate = bill.closeDate;
            return printBillData;
        }

        public Bill createBillInShop(int idEmployee)
        {
            int maxBillId = 0;
            if (_dbContext.Bills.Count() > 0)
            {
                maxBillId = _dbContext.Bills.Max(x => x.billId);
            }
            Bill bill = new Bill();
            bill.billCode = "HD" + (maxBillId + 1);
            bill.idEmployee = idEmployee;
            bill.createDate = DateTime.Now;
            bill.billStatusId = 7;
            _dbContext.Add(bill);
            _dbContext.SaveChanges();
            return bill;
        }

        public HoldBill getAllBillDetailOfBill(int idBill)
        {
            HoldBill hb = new HoldBill();
            Bill bill = _dbContext.Bills.Include(x => x.billDetails).ThenInclude(x => x.product).ThenInclude(x => x.productImgs).FirstOrDefault(x => x.billId == idBill);
            List<BillDetailAndProduct> billDetailAndProducts = new List<BillDetailAndProduct>();
            foreach (var bd in bill.billDetails)
            {
                BillDetailAndProduct bdap = new BillDetailAndProduct();
                bdap.billDetail = bd;
                if (bill.createDate != null)
                {
                    bdap.createDate = bill.createDate;
                }
                bdap.product = bd.product;
                billDetailAndProducts.Add(bdap);
            }
            hb.bill = bill;
            hb.sales = _dbContext.Sales.Where(x => x.saleTypeId == 2).ToList();
            hb.billDetailAndProductList = billDetailAndProducts;
            return hb;
        }

        public void addProduct2BillDetail(int idProduct, int idBill)
        {
            BillDetail bd = new BillDetail();
            bd.productId = idProduct;
            bd.billId = idBill;
            bd.quantity = 1;
            bd.price = (double)_dbContext.Products.FirstOrDefault(x => x.productId == idProduct).shellPrice;
            _dbContext.Add(bd);
            _dbContext.SaveChanges();
        }

        public void deleteBillDetail(int idBillDetail)
        {
            var bd = _dbContext.BillDetails.FirstOrDefault(x => x.billDetailId == idBillDetail);
            if (bd == null) return;
            _dbContext.Remove(bd);
            _dbContext.SaveChanges();
        }

        public void updateQuantityBillDetail(int idBillDetail, int quantity)
        {
            var bd = _dbContext.BillDetails.FirstOrDefault(x => x.billDetailId == idBillDetail);
            bd.quantity = quantity;
            _dbContext.Update(bd);
            _dbContext.SaveChanges();
        }

        public void payHoldBill(HoldBillRequestPayBill holdBillRequestPayBill)
        {
            Bill bill = _dbContext.Bills.Include(x => x.billDetails).FirstOrDefault(x => x.billId == holdBillRequestPayBill.idBill);
            if (holdBillRequestPayBill.customerSdt.Trim().Length > 0)
            {
                AccountShipContact asc = new AccountShipContact();
                //asc.accountId = 41;
                asc.accountPhoneNumber = holdBillRequestPayBill.customerSdt.Trim();
                asc.accountDetailAddress = holdBillRequestPayBill.customAddress;
                asc.receiverName = holdBillRequestPayBill.customerName;
                _dbContext.Add(asc);
                _dbContext.SaveChanges();
            }
            bill.idEmployee = holdBillRequestPayBill.idEmployee;
            bill.receivedDate = DateTime.Now;
            bill.closeDate = DateTime.Now;
            bill.billStatusId = 3;
            bill.shipPrice = 0d;
            bill.buyMethodId = holdBillRequestPayBill.idBuyMethod;
            _dbContext.Update(bill);
            _dbContext.SaveChanges();
            if (holdBillRequestPayBill.idVoucher != 0)
            {
                BillSales bs = new BillSales();
                bs.salesId = holdBillRequestPayBill.idVoucher;
                bs.billId = bill.billId;
                _dbContext.Add(bs);
                _dbContext.SaveChanges();
            }
            foreach (var bd in bill.billDetails)
            {
                Product p = _dbContext.Products.FirstOrDefault(x => x.productId == bd.productId);
                p.quantity = p.quantity - bd.quantity;
                _dbContext.Update(p);
                _dbContext.SaveChanges();
            }
        }

        public List<Bill> getAllHoldingBill()
        {
            return _dbContext.Bills.Where(x => x.billStatusId == 7).OrderByDescending(x => x.billId).ToList();
        }

        public async Task<Analysis> GetAnalysisData()
        {
            int productCountShelling = await _dbContext.Products.Where(x => x.productStatusId == 1).CountAsync();
            int voucherCountUsing = await _dbContext.Sales.Where(x => x.salessStatusId == 1).CountAsync();
            int? productQuantityInventory = await _dbContext.Products.Where(x => x.productStatusId == 1).SumAsync(x => x.quantity);
            int custumerCountActive = await _dbContext.Accounts.Where(x => x.accountStatusId == 1 && x.roleID == 3).CountAsync();
            var query1 = from p in _dbContext.Products
                         join bd in _dbContext.BillDetails
                         on p.productId equals bd.productId
                         join b in _dbContext.Bills
                         on bd.billId equals b.billId
                         where b.billStatusId == 3 && b.createDate.Month == DateTime.Now.Month
                         group new { p, bd } by p.productId into t
                         select new TopProductSold()
                         {
                             name = t.FirstOrDefault().p.productName,
                             sold = t.Sum(x => x.bd.quantity),
                             inventory = t.Sum(x => x.p.quantity - x.bd.quantity),
                             productCode = t.FirstOrDefault().p.productDetail
                         };
            var top5ProductSolds = await query1.Take(5).OrderByDescending(x => x.sold).ToListAsync();

            var query2 = from a in _dbContext.Accounts
                         join asc in _dbContext.AccountShipContacts
                         on a.accountId equals asc.accountId
                         join b in _dbContext.Bills
                         on asc.accountShipContactId equals b.accountShipContactId
                         join bd in _dbContext.BillDetails
                         on b.billId equals bd.billId
                         where b.billStatusId == 3 && b.createDate.Month == DateTime.Now.Month
                         group new { a, bd } by a.accountId into t
                         select new TopAccountPaid()
                         {
                             accountCode = t.FirstOrDefault().a.accountUserName,
                             sdt = t.FirstOrDefault().a.sdt,
                             name = t.FirstOrDefault().a.accountName,
                             totalPaid = t.Sum(x => x.bd.price)
                         };
            var top5AccountPaids = await query2.Take(5).OrderByDescending(x => x.totalPaid).ToListAsync();

            var totalBillMonth = new List<int>();
            for (int i = 0; i <= 12; i++)
            {
                var billMonth = await _dbContext.Bills.CountAsync(x => x.createDate.Month == i + 1);
                totalBillMonth.Add(billMonth);
            }

            var analysisProfit12Month = new List<MonthAnalysis>();
            for (int i = 1; i <= 12; i++)
            {
                var bills = await _dbContext.Bills.Where(x => x.createDate.Month == i && x.billStatusId == 3).ToListAsync();
                int soldTotal = 0;
                double? profitBefore = 0d;
                foreach (var bill in bills)
                {
                    var totalProductOfBill = await _dbContext.BillDetails.Where(x => x.billId == bill.billId).CountAsync();
                    soldTotal += totalProductOfBill;

                    double? totalPriceBill = 0d;
                    var billDetails = await _dbContext.BillDetails.Where(x => x.billId == bill.billId).Include(x => x.product).ToListAsync();
                    foreach (var billDetail in billDetails)
                    {
                        totalPriceBill += billDetail.price * billDetail.quantity;
                        profitBefore += billDetail.product.price * billDetail.quantity;
                    }
                    var billSales = await _dbContext.BillSales.Where(x => x.billId == bill.billId).Include(x => x.sales).ToListAsync();
                    Double freeShip = 0d;
                    Double voucher = 0d;
                    foreach (var item in billSales)
                    {
                        if (item.sales.saleTypeId == 1)
                        {
                            freeShip = (double)item.sales.salesInt;
                        }
                        if (item.sales.saleTypeId == 2)
                        {
                            voucher = (double)(item.sales.salesInt + item.sales.salesPercent);

                        }
                    }
                    if (voucher > 100)
                        totalPriceBill -= voucher;
                    else
                        totalPriceBill -= totalPriceBill * voucher / 100;
                    totalPriceBill -= freeShip;
                    totalPriceBill -= profitBefore;
                }

                double? shipLossTotal = await _dbContext.Bills.Where(x => x.createDate.Month == i && x.billStatusId == 5).SumAsync(x => x.shipPrice);
                var monthAnalysis = new MonthAnalysis()
                {
                    shippedBillTotal = bills.Count,
                    soldTotal = soldTotal,
                    backBillTotal = await _dbContext.Bills.Where(x => x.createDate.Month == i && x.billStatusId == 5).CountAsync(),
                    profitBefore = profitBefore,
                    shipLossTotal = shipLossTotal,
                    resultProfit = profitBefore - shipLossTotal,
                };
                analysisProfit12Month.Add(monthAnalysis);
            }

            var analysisData = new Analysis()
            {
                productCountShelling = productCountShelling,
                voucherCountUsing = voucherCountUsing,
                productQuantityInventory = productQuantityInventory,
                custumerCountActive = custumerCountActive,
                top5ProductSold = top5ProductSolds,
                analysisProfit12Month = analysisProfit12Month,
                top5AccountPaid = top5AccountPaids,
                totalBillMonth = totalBillMonth,
            };
            return analysisData;
        }
    }
}


