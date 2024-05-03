using ClothShop.DAO;
using ClothShop.Entities;
using ClothShop.Entities.requestobject;
using ClothShop.Entities.responsobject;
using ClothShop.Helpers;
using ClothShop.IServices;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Drawing;

namespace ClothShop.Services
{
    public class AppService : IAppService
    {
        private readonly AppDbContext dbContext;
        public AppService(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public AccountShipContact AddAccountShipContact(AccountShipContact accountShipContact)
        {
            accountShipContact.accountShipContactStatusId = 1;
            dbContext.Add(accountShipContact);
            dbContext.SaveChanges();
            return accountShipContact;
        }

        public AccountShipContact RemoveAccountShipContact(int idAccountShipContact)
        {
            var shipAcc = dbContext.AccountShipContacts.FirstOrDefault(x => x.accountShipContactId == idAccountShipContact);
            if (shipAcc == null)
            {
                return null;
            }
            shipAcc.accountShipContactStatusId = 2;
            dbContext.Update(shipAcc);
            dbContext.SaveChanges();
            return shipAcc;
        }

        public AccountRemakeInfo RemakeAccountInfo(AccountRemakeInfo accountRemakeInfo)
        {
            var remakeAcc = dbContext.Accounts.FirstOrDefault(x => x.accountId == accountRemakeInfo.accountId);
            if (remakeAcc == null)
            {
                return null;
            }
            remakeAcc.accountName = accountRemakeInfo.name;
            remakeAcc.accountDetailAddress = accountRemakeInfo.address;
            remakeAcc.accountBorn = accountRemakeInfo.born;
            remakeAcc.sdt = accountRemakeInfo.sdt;
            remakeAcc.updateDate = DateTime.Now;
            dbContext.Accounts.Update(remakeAcc);
            dbContext.SaveChanges();
            return accountRemakeInfo;
        }

        public RemakePassRes RemakePassword(RemakePassReq remakePassReq)
        {
            RemakePassRes remakePassRes = new RemakePassRes();
            var remake = dbContext.Accounts.FirstOrDefault(x => x.accountId == remakePassReq.accountId);
            if (remake == null)
            {
                remakePassRes.status = 1;
                remakePassRes.detail = "Khong ton tai tai khoan!";
                return remakePassRes;
            }
            if (!remake.accountPassword.Equals(remakePassReq.oldPass))
            {
                remakePassRes.status = 2;
                remakePassRes.detail = "Mat khau cu khong chinh xac!";
                return remakePassRes;
            }
            remake.accountPassword = remakePassReq.newPass;
            dbContext.Accounts.Update(remake);
            dbContext.SaveChanges();
            remakePassRes.status = 3;
            remakePassRes.detail = "Doi mat khau thanh cong";
            return remakePassRes;
        }

        public AccountCustom CheckLogin(string userName, string userPass)
        {
            var account = dbContext.Accounts.FirstOrDefault(x => x.accountUserName == userName && x.accountPassword == userPass);
            AccountCustom dsResult = new AccountCustom();
            if (account == null)
            {
                dsResult.status = 200;
                return dsResult;
            }

            dsResult.roleID = account.roleID;
            dsResult.Id = account.accountId;
            dsResult.address = account.accountDetailAddress;
            dsResult.name = account.accountName;
            dsResult.shipContacts = account.accountShipContacts;
            return dsResult;
        }

        public CreateAccountData CreateAccount(CreateAccountData accountData)
        {

            Accounts account = new Accounts();
            AccountShipContact accountShipContact = new AccountShipContact();
            if (!dbContext.Accounts.Any(x => x.accountUserName == accountData.userName))
            {
                account.sdt = accountData.sdt;
                account.accountDetailAddress = accountData.address;
                account.accountName = accountData.name;
                account.accountUserName = accountData.userName;
                account.accountPassword = accountData.userPass;
                var statusOnline = dbContext.AccountStatuses.FirstOrDefault(x => x.accountStatusId == 1);
                account.accountStatusId = statusOnline.accountStatusId;
                var role = dbContext.Roles.FirstOrDefault(x => x.roleID == 3);
                account.roleID = role.roleID;
                account.createDate = DateTime.Now;
                dbContext.Accounts.Add(account);
                dbContext.SaveChanges();
                /*accountShipContact.accountPhoneNumber = accountData.sdt;
                accountShipContact.accountDetailAdress = accountData.address;
                accountShipContact.receiverName = accountData.name;
                accountShipContact.accountID = account.accountID;
                dbContext.AccountShipContacts.Add(accountShipContact);
                dbContext.SaveChanges();*/
                accountData.userPass = "";
                accountData.id = account.accountId;
                return accountData;
            }
            else
            {
                accountData.status = 1;
                return accountData;
            }
        }

        public AccountCustom GetContact(int accountId)
        {
            var accountLb = dbContext.Accounts.Include(x => x.accountShipContacts).FirstOrDefault(x => x.accountId == accountId);
            if (accountLb == null)
            {
                return null;
            }
            AccountCustom result = new AccountCustom();
            result.Id = accountLb.accountId;
            result.address = accountLb.accountDetailAddress;
            result.name = accountLb.accountName;
            result.sdt = accountLb.sdt;
            result.born = accountLb.accountBorn;
            result.shipContacts = dbContext.AccountShipContacts.Include(x => x.accountShipContactStatus).Include(x => x.account).Include(x => x.bills).Where(x => x.accountId == accountId && x.accountShipContactStatusId == 1).ToList();
            return result;
        }

        public List<OrderRes> GetBillDetailByAccountId(int accountId)
        {
            var account = dbContext.Accounts.Include(x => x.accountShipContacts).FirstOrDefault(x => x.accountId == accountId);
            account.accountShipContacts = dbContext.AccountShipContacts.Include(x => x.bills).ThenInclude(x => x.billSalesList).ThenInclude(x => x.sales).ThenInclude(x => x.saleType)
                .Include(x => x.bills).ThenInclude(x => x.billDetails).ThenInclude(x => x.product)
                .Include(x => x.bills).ThenInclude(x => x.shipMethod)
                .Include(x => x.bills).ThenInclude(x => x.billStatus)
                .Where(x => x.accountId == accountId && x.accountShipContactStatusId == 1).ToList();
            if (account == null)
            {
                return null;
            }
            if (account.accountShipContacts == null)
            {
                return null;
            }

            List<AccountShipContact> lstAccShipContact = account.accountShipContacts;
            List<OrderRes> lstResult = new List<OrderRes>();
            foreach (var a in lstAccShipContact)
            {
                foreach (var bill in a.bills)
                {
                    OrderRes orderRes = new OrderRes();
                    orderRes.accountShipContact = a;
                    orderRes.bill = bill;
                    orderRes.billStatus = bill.billStatus;
                    orderRes.buyMethod = bill.buyMethod;
                    foreach (var bs in bill.billSalesList)
                    {
                        if (bs.sales.saleType.saleTypeId == 1)
                        {
                            orderRes.freeShip = bs.sales.salesInt + bs.sales.salesPercent;
                        }
                        if (bs.sales.saleType.saleTypeId == 2)
                        {
                            orderRes.voucherSIXDO = bs.sales.salesInt + bs.sales.salesPercent;
                        }
                    }
                    orderRes.shipMethod = bill.shipMethod;
                    List<ProductBillDetail> pd = new List<ProductBillDetail>();
                    foreach (BillDetail billDetail in bill.billDetails)
                    {
                        ProductBillDetail pdb = new ProductBillDetail();
                        pdb.product = billDetail.product;
                        pdb.billDetail = billDetail;
                        pd.Add(pdb);
                    }
                    orderRes.productBillDetail = pd;
                    lstResult.Add(orderRes);
                }
            }
            return lstResult;
        }

        public List<Product> getProductHome()
        {
            var dsProductHome = dbContext.Products.ToList();
            return dsProductHome.GetRange(0, 9);
        }

        public Pagination<Product> nextPage(int page, int? filter)
        {
            List<Product> product;
            if (filter != null)
            {
                product = dbContext.Products.Include(x => x.productImgs).Include(x => x.brand).Include(x => x.producer).Include(x => x.size).Include(x => x.color).Include(x => x.categoryType).Where(a => a.categoryTypeId == filter).ToList();
            }
            else
            {
                product = dbContext.Products.Include(x => x.productImgs).Include(x => x.brand).Include(x => x.producer).Include(x => x.size).Include(x => x.color).Include(x => x.categoryType).ToList();
            }
            int size = product.Count;
            if (size <= 6)
            {
                return new Pagination<Product>(size, product);
            }
            return new Pagination<Product>(size, product.GetRange(page * 6 - 6, Math.Min(size, page * 6)));
        }

        public ProductDetail GetProductId(int id)
        {
            var prDetail = new ProductDetail();
            var p = dbContext.Products.Include(x => x.productImgs).Include(x => x.brand).Include(x => x.producer).Include(x => x.size).Include(x => x.color).Include(x => x.categoryType).FirstOrDefault(x => x.productId == id);
            prDetail.product = p;
            prDetail.brand = p.brand;
            prDetail.producer = p.producer;
            prDetail.size = p.size;
            prDetail.color = p.color;
            prDetail.categoryType = p.categoryType;
            return prDetail;
        }

        public AccountBag AddProduct2Bag(int accountId, int productId, int quantity)
        {
            AccountBag accountBagCheck = dbContext.AccountBags.FirstOrDefault(x => x.accountId == accountId && x.productId == productId);
            if (accountBagCheck != null)
            {
                accountBagCheck.quantity = accountBagCheck.quantity + quantity;
                dbContext.Update(accountBagCheck);
                dbContext.SaveChanges();
            }
            AccountBag accountBag = new AccountBag();
            accountBag.account = dbContext.Accounts.FirstOrDefault(x => x.accountId == accountId);
            accountBag.product = dbContext.Products.FirstOrDefault(x => x.productId == productId);
            accountBag.quantity = quantity;
            dbContext.Add(accountBag);
            dbContext.SaveChanges();
            return accountBag;
        }

        public List<ShowAccountBag> GetProductBagByAccountID(int accountId)
        {
            List<ShowAccountBag> result = new List<ShowAccountBag>();
            List<AccountBag> lstAccountBag = dbContext.AccountBags.Include(x => x.product).Include(x => x.account).Where(x => x.accountId == accountId).ToList();
            foreach (var item in lstAccountBag)
            {
                ShowAccountBag showAccountBag = new ShowAccountBag();
                showAccountBag.accountBag = item;
                showAccountBag.product = dbContext.Products.Include(x => x.productImgs).Include(x => x.categoryType).FirstOrDefault(x => x.productId == item.productId);
                showAccountBag.categoryType = item.product.categoryType;
                result.Add(showAccountBag);
            }
            return result;
        }

        public AccountBag updateAccountBag(int[] accountBagData)
        {
            AccountBag accountBag = dbContext.AccountBags.FirstOrDefault(x => x.accountBagId == accountBagData[0]);
            accountBag.quantity = accountBagData[1];
            dbContext.Update(accountBag);
            dbContext.SaveChanges();
            return accountBag;
        }

        public AccountBag deleteAccountBag(int accountBagId)
        {
            var accountBag = dbContext.AccountBags.FirstOrDefault(x => x.accountBagId == accountBagId);
            if (accountBag == null)
            {
                return null;
            }
            dbContext.AccountBags.Remove(accountBag);
            dbContext.SaveChanges();
            return accountBag;
        }

        public CreateOrder GetCalCulBag(int[] listIdAccountBag)
        {
            CreateOrder co = new CreateOrder();
            List<OrderItem> orderItems = new List<OrderItem>();
            List<Sales> salesOfBill = dbContext.Sales.Include(x => x.saleType).Where(x => x.salessStatusId == 1 || x.salessStatusId == 2).ToList();
            List<ShipMethod> shipMethods = dbContext.ShipMethods.ToList();
            List<BuyMethod> buyMethods = dbContext.BuyMethods.ToList();
            var accountShipContacts = dbContext.AccountShipContacts.Include(x => x.account).ThenInclude(a => a.accountBags).ToList();
            foreach (var i in listIdAccountBag)
            {
                OrderItem oi = new OrderItem();
                AccountBag ab = dbContext.AccountBags.Include(x => x.account).Include(x => x.product).ThenInclude(x => x.categoryType).Include(x => x.product).ThenInclude(x => x.productImgs).FirstOrDefault(x => x.accountBagId == i);
                oi.accountBagId = i;
                oi.product = ab.product;
                oi.quantity = ab.quantity;
                oi.categoryType = ab.product.categoryType;
                orderItems.Add(oi);
            }
            co.accountShipContacts = accountShipContacts;
            co.orderItems = orderItems;
            co.salesOfBill = salesOfBill;
            co.buyMethods = buyMethods;
            co.shipMethods = shipMethods;
            return co;
        }

        public OrderData createBill(OrderData orderData)
        {
            Bill bill = new Bill();
            bill.billStatusId = 1;
            bill.shipMethodId = orderData.shipOptId;
            bill.buyMethodId = orderData.buyOptId;
            bill.createDate = DateTime.Now;
            bill.buyerNotification = orderData.buyerNotification;
            bill.accountShipContactId = orderData.accountShipContactId;
            bill.shipPrice = orderData.shipPrice;
            dbContext.Add(bill);
            dbContext.SaveChanges();
            bill.billCode = "HD" + bill.billId;
            double totalBill = 0;
            foreach (var accountBagId in orderData.accountBags)
            {
                AccountBag ab = dbContext.AccountBags.Include(x => x.product).FirstOrDefault(x => x.accountBagId == accountBagId);
                BillDetail bd = new BillDetail();
                bd.billId = bill.billId;
                bd.productId = ab.productId;
                bd.quantity = ab.quantity;
                double price = (double)(ab.product.shellPrice * ab.quantity);
                bd.price = price;
                totalBill += price;
                dbContext.Add(bd);
                dbContext.SaveChanges();
            }
            if (orderData.shipVoucher != null)
            {
                BillSales bs = new BillSales();
                bs.billId = bill.billId;
                bs.salesId = orderData.shipVoucher;
                dbContext.Add(bs);
                dbContext.SaveChanges();
            }
            if (orderData.voucherVoucher != null)
            {
                BillSales bs = new BillSales();
                bs.billId = bill.billId;
                bs.salesId = orderData.voucherVoucher;
                dbContext.Add(bs);
                dbContext.SaveChanges();
            }
            bill.totalBill = totalBill;
            dbContext.Update(bill);
            dbContext.SaveChanges();
            return orderData;
        }

        public List<Product> searchProduct(string search)
        {
            List<Product> product = dbContext.Products.Where(x => x.productName.Contains(search) || x.productDetail.Contains(search)).ToList();
            return product;
        }
        public Bill cancelBill(int billId, int type)
        {
            var bill = dbContext.Bills.Include(x => x.billDetails).ThenInclude(x => x.product).FirstOrDefault(x => x.billId == billId);
            if (bill == null)
            {
                return null;
            }
            Bill getBill = bill;
            DateTime today = DateTime.Now;
            switch (type)
            {
                case 1:
                    getBill.shipToBuyerDate = today.AddDays(5);
                    getBill.billStatusId = 2;
                    foreach (var bd in getBill.billDetails)
                    {
                        Product p = bd.product;
                        p.quantity = p.quantity - bd.quantity;
                        dbContext.Update(p);
                        dbContext.SaveChanges();
                    }
                    dbContext.Update(getBill);
                    dbContext.SaveChanges();
                    return getBill;
                case 2:
                    getBill.closeDate = today;
                    getBill.billStatusId = 4;
                    dbContext.Update(getBill);
                    dbContext.SaveChanges();
                    foreach (var bd in getBill.billDetails)
                    {
                        Product p = bd.product;
                        p.quantity = p.quantity + bd.quantity;
                        dbContext.Update(p);
                        dbContext.SaveChanges();
                    }
                    return getBill;
                case 3:
                    getBill.closeDate = today;
                    getBill.billStatusId = 5;
                    dbContext.Update(getBill);
                    dbContext.SaveChanges();
                    foreach (var bd in getBill.billDetails)
                    {
                        Product p = bd.product;
                        p.quantity = p.quantity + bd.quantity;
                        dbContext.Update(p);
                        dbContext.SaveChanges();
                    }
                    return getBill;
                default:
                    return null;
            }
        }
        /*public List<Product> nextPage(int page)
        {
            List<Product> dsAll = dbContext.Products.ToList();
            if (page * 9 + 9 >= dsAll.Count())
            {
                return dsAll.GetRange(dsAll.Count() - 10, dsAll.Count() - 1);
            }
            return dsAll.GetRange(page * 9 - 9, page * 9);
        }*/
    }
}
