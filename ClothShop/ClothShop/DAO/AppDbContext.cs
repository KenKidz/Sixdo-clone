using ClothShop.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothShop.DAO
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context)
        {

        }
        public virtual DbSet<AccountBag> AccountBags { get; set; }
        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<AccountShipContact> AccountShipContacts { get; set; }
        public virtual DbSet<AccountShipContactStatus> AccountShipContactStatuses { get; set; }
        public virtual DbSet<AccountStatus> AccountStatuses { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BillDetail> BillDetails { get; set; }
        public virtual DbSet<BillSales> BillSales { get; set; }
        public virtual DbSet<BillStatus> BillStatuses { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<BuyMethod> BuyMethods { get; set; }
        public virtual DbSet<CategoryType> CategoryTypes { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Producer> Producers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImg> ProductImgs { get; set; }
        public virtual DbSet<ProductStatus> ProductStatuses { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<SalesStatus> SalesStatuses { get; set; }
        public virtual DbSet<SaleType> SaleTypes { get; set; }
        public virtual DbSet<ShipMethod> ShipMethods { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<VoteStar> VoteStars { get; set; }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server = KENKID\\SQLEXPRESS; Database = ClothesShop; Trusted_Connection = True; TrustServerCertificate = True");
        }*/

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductImg>()
                .HasOne(_ => _.product)
                .WithMany(a => a.ProductImgs)
                .HasForeignKey(p => p.productId);
        }*/
    }
}
