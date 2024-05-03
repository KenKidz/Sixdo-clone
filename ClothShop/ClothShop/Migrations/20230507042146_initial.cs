using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothShop.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountShipContactStatuses",
                columns: table => new
                {
                    accountShipContactStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountShipContactStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountShipContactStatusDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountShipContactStatuses", x => x.accountShipContactStatusId);
                });

            migrationBuilder.CreateTable(
                name: "AccountStatuses",
                columns: table => new
                {
                    accountStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountStatusDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStatuses", x => x.accountStatusId);
                });

            migrationBuilder.CreateTable(
                name: "BillStatuses",
                columns: table => new
                {
                    billStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    billStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    billStatusDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillStatuses", x => x.billStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    brandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brandCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    brandDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.brandId);
                });

            migrationBuilder.CreateTable(
                name: "BuyMethods",
                columns: table => new
                {
                    buyMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    buyMethodCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    buyMethodName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyMethods", x => x.buyMethodId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTypes",
                columns: table => new
                {
                    categoryTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryTypeDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTypes", x => x.categoryTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    colorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    colorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    colorDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.colorId);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    producerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    producerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    producerDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.producerId);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatuses",
                columns: table => new
                {
                    productStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productStatusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productStatusDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatuses", x => x.productStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    roleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roleDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.roleID);
                });

            migrationBuilder.CreateTable(
                name: "SalesStatuses",
                columns: table => new
                {
                    salessStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    statusDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesStatuses", x => x.salessStatusId);
                });

            migrationBuilder.CreateTable(
                name: "SaleTypes",
                columns: table => new
                {
                    saleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    saleTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    saleTypeDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleTypes", x => x.saleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ShipMethods",
                columns: table => new
                {
                    shipMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shipMethodCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shipMethodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipMethods", x => x.shipMethodId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    sizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sizeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sizeDetail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.sizeId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    accountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountStatusId = table.Column<int>(type: "int", nullable: true),
                    accountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountBorn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    accountDetailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountCreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    roleID = table.Column<int>(type: "int", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sdt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.accountId);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountStatuses_accountStatusId",
                        column: x => x.accountStatusId,
                        principalTable: "AccountStatuses",
                        principalColumn: "accountStatusId");
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_roleID",
                        column: x => x.roleID,
                        principalTable: "Roles",
                        principalColumn: "roleID");
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    salesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salesCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salesName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    salesPercent = table.Column<int>(type: "int", nullable: true),
                    salesInt = table.Column<int>(type: "int", nullable: true),
                    openDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    salessStatusId = table.Column<int>(type: "int", nullable: true),
                    saleTypeId = table.Column<int>(type: "int", nullable: true),
                    salesStatussalessStatusId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.salesId);
                    table.ForeignKey(
                        name: "FK_Sales_SalesStatuses_salesStatussalessStatusId",
                        column: x => x.salesStatussalessStatusId,
                        principalTable: "SalesStatuses",
                        principalColumn: "salessStatusId");
                    table.ForeignKey(
                        name: "FK_Sales_SaleTypes_saleTypeId",
                        column: x => x.saleTypeId,
                        principalTable: "SaleTypes",
                        principalColumn: "saleTypeId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    productDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryTypeId = table.Column<int>(type: "int", nullable: true),
                    sizeId = table.Column<int>(type: "int", nullable: true),
                    colorId = table.Column<int>(type: "int", nullable: true),
                    brandId = table.Column<int>(type: "int", nullable: true),
                    producerId = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    shellPrice = table.Column<int>(type: "int", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    productStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_brandId",
                        column: x => x.brandId,
                        principalTable: "Brands",
                        principalColumn: "brandId");
                    table.ForeignKey(
                        name: "FK_Products_CategoryTypes_categoryTypeId",
                        column: x => x.categoryTypeId,
                        principalTable: "CategoryTypes",
                        principalColumn: "categoryTypeId");
                    table.ForeignKey(
                        name: "FK_Products_Colors_colorId",
                        column: x => x.colorId,
                        principalTable: "Colors",
                        principalColumn: "colorId");
                    table.ForeignKey(
                        name: "FK_Products_Producers_producerId",
                        column: x => x.producerId,
                        principalTable: "Producers",
                        principalColumn: "producerId");
                    table.ForeignKey(
                        name: "FK_Products_ProductStatuses_productStatusId",
                        column: x => x.productStatusId,
                        principalTable: "ProductStatuses",
                        principalColumn: "productStatusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Sizes_sizeId",
                        column: x => x.sizeId,
                        principalTable: "Sizes",
                        principalColumn: "sizeId");
                });

            migrationBuilder.CreateTable(
                name: "AccountShipContacts",
                columns: table => new
                {
                    accountShipContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(type: "int", nullable: true),
                    receiverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountDetailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountShipContactStatusId = table.Column<int>(type: "int", nullable: true),
                    districtID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    provinceID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wardCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountShipContacts", x => x.accountShipContactId);
                    table.ForeignKey(
                        name: "FK_AccountShipContacts_Accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "Accounts",
                        principalColumn: "accountId");
                    table.ForeignKey(
                        name: "FK_AccountShipContacts_AccountShipContactStatuses_accountShipContactStatusId",
                        column: x => x.accountShipContactStatusId,
                        principalTable: "AccountShipContactStatuses",
                        principalColumn: "accountShipContactStatusId");
                });

            migrationBuilder.CreateTable(
                name: "AccountBags",
                columns: table => new
                {
                    accountBagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountId = table.Column<int>(type: "int", nullable: true),
                    productId = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBags", x => x.accountBagId);
                    table.ForeignKey(
                        name: "FK_AccountBags_Accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "Accounts",
                        principalColumn: "accountId");
                    table.ForeignKey(
                        name: "FK_AccountBags_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId");
                });

            migrationBuilder.CreateTable(
                name: "ProductImgs",
                columns: table => new
                {
                    productImgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: false),
                    countImg = table.Column<int>(type: "int", nullable: true),
                    productImg = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImgs", x => x.productImgId);
                    table.ForeignKey(
                        name: "FK_ProductImgs_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoteStars",
                columns: table => new
                {
                    voteStarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productId = table.Column<int>(type: "int", nullable: true),
                    accountId = table.Column<int>(type: "int", nullable: true),
                    starVoted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteStars", x => x.voteStarId);
                    table.ForeignKey(
                        name: "FK_VoteStars_Accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "Accounts",
                        principalColumn: "accountId");
                    table.ForeignKey(
                        name: "FK_VoteStars_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId");
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    billId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountShipContactId = table.Column<int>(type: "int", nullable: true),
                    buyMethodId = table.Column<int>(type: "int", nullable: true),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    shipToBuyerDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    receivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    closeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    billStatusId = table.Column<int>(type: "int", nullable: true),
                    totalBill = table.Column<double>(type: "float", nullable: false),
                    productReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    buyerNotification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shipMethodId = table.Column<int>(type: "int", nullable: true),
                    shipPrice = table.Column<double>(type: "float", nullable: false),
                    billCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idEmployee = table.Column<int>(type: "int", nullable: true),
                    employeeaccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.billId);
                    table.ForeignKey(
                        name: "FK_Bills_Accounts_employeeaccountId",
                        column: x => x.employeeaccountId,
                        principalTable: "Accounts",
                        principalColumn: "accountId");
                    table.ForeignKey(
                        name: "FK_Bills_AccountShipContacts_accountShipContactId",
                        column: x => x.accountShipContactId,
                        principalTable: "AccountShipContacts",
                        principalColumn: "accountShipContactId");
                    table.ForeignKey(
                        name: "FK_Bills_BillStatuses_billStatusId",
                        column: x => x.billStatusId,
                        principalTable: "BillStatuses",
                        principalColumn: "billStatusId");
                    table.ForeignKey(
                        name: "FK_Bills_BuyMethods_buyMethodId",
                        column: x => x.buyMethodId,
                        principalTable: "BuyMethods",
                        principalColumn: "buyMethodId");
                    table.ForeignKey(
                        name: "FK_Bills_ShipMethods_shipMethodId",
                        column: x => x.shipMethodId,
                        principalTable: "ShipMethods",
                        principalColumn: "shipMethodId");
                });

            migrationBuilder.CreateTable(
                name: "BillDetails",
                columns: table => new
                {
                    billDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    billId = table.Column<int>(type: "int", nullable: true),
                    productId = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetails", x => x.billDetailId);
                    table.ForeignKey(
                        name: "FK_BillDetails_Bills_billId",
                        column: x => x.billId,
                        principalTable: "Bills",
                        principalColumn: "billId");
                    table.ForeignKey(
                        name: "FK_BillDetails_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId");
                });

            migrationBuilder.CreateTable(
                name: "BillSales",
                columns: table => new
                {
                    billSalesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salesId = table.Column<int>(type: "int", nullable: true),
                    billId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillSales", x => x.billSalesId);
                    table.ForeignKey(
                        name: "FK_BillSales_Bills_billId",
                        column: x => x.billId,
                        principalTable: "Bills",
                        principalColumn: "billId");
                    table.ForeignKey(
                        name: "FK_BillSales_Sales_salesId",
                        column: x => x.salesId,
                        principalTable: "Sales",
                        principalColumn: "salesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountBags_accountId",
                table: "AccountBags",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBags_productId",
                table: "AccountBags",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_accountStatusId",
                table: "Accounts",
                column: "accountStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_roleID",
                table: "Accounts",
                column: "roleID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountShipContacts_accountId",
                table: "AccountShipContacts",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountShipContacts_accountShipContactStatusId",
                table: "AccountShipContacts",
                column: "accountShipContactStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_billId",
                table: "BillDetails",
                column: "billId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_productId",
                table: "BillDetails",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_accountShipContactId",
                table: "Bills",
                column: "accountShipContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_billStatusId",
                table: "Bills",
                column: "billStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_buyMethodId",
                table: "Bills",
                column: "buyMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_employeeaccountId",
                table: "Bills",
                column: "employeeaccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_shipMethodId",
                table: "Bills",
                column: "shipMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_BillSales_billId",
                table: "BillSales",
                column: "billId");

            migrationBuilder.CreateIndex(
                name: "IX_BillSales_salesId",
                table: "BillSales",
                column: "salesId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImgs_productId",
                table: "ProductImgs",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_brandId",
                table: "Products",
                column: "brandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_categoryTypeId",
                table: "Products",
                column: "categoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_colorId",
                table: "Products",
                column: "colorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_producerId",
                table: "Products",
                column: "producerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_productStatusId",
                table: "Products",
                column: "productStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_sizeId",
                table: "Products",
                column: "sizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_salesStatussalessStatusId",
                table: "Sales",
                column: "salesStatussalessStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_saleTypeId",
                table: "Sales",
                column: "saleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteStars_accountId",
                table: "VoteStars",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteStars_productId",
                table: "VoteStars",
                column: "productId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountBags");

            migrationBuilder.DropTable(
                name: "BillDetails");

            migrationBuilder.DropTable(
                name: "BillSales");

            migrationBuilder.DropTable(
                name: "ProductImgs");

            migrationBuilder.DropTable(
                name: "VoteStars");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AccountShipContacts");

            migrationBuilder.DropTable(
                name: "BillStatuses");

            migrationBuilder.DropTable(
                name: "BuyMethods");

            migrationBuilder.DropTable(
                name: "ShipMethods");

            migrationBuilder.DropTable(
                name: "SalesStatuses");

            migrationBuilder.DropTable(
                name: "SaleTypes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "CategoryTypes");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "ProductStatuses");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountShipContactStatuses");

            migrationBuilder.DropTable(
                name: "AccountStatuses");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
