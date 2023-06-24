using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDTConfigurationTable;
using TDTSettingTable;

namespace CodeFirtMigration.DataFE
{
    public class ContextFE : IdentityDbContext<UserAccount, Role, Guid>
    {
        public ContextFE(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Table Configuration For Creating 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AreaMasterConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BankSuportsConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryItemMasterConfiguration());
            modelBuilder.ApplyConfiguration(new CitysConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerAddressOrdersConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerCartConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerReviewConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerWalletConfiguration());
            modelBuilder.ApplyConfiguration(new DistrictsConfiguration());
            modelBuilder.ApplyConfiguration(new FreeShipProgramConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new HistoryWalletConfiguration());
            modelBuilder.ApplyConfiguration(new ImageItemMasterConfiguration());
            modelBuilder.ApplyConfiguration(new ImageReviewConfiguration());
            modelBuilder.ApplyConfiguration(new IssuingCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new ItemMasterConfiguration());
            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new MarriageConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PairDiscountConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodsConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsviewedbycustomersConfiguration());
            modelBuilder.ApplyConfiguration(new PublishingCompanyConfiguration());
            modelBuilder.ApplyConfiguration(new QuantityDiscountConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptPaymentOnlineConfiguration());
            modelBuilder.ApplyConfiguration(new ReceiptStatusConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SatisfactionLevelConfiguration());
            modelBuilder.ApplyConfiguration(new SpecialDiscountConfiguration());
            modelBuilder.ApplyConfiguration(new TypeAddressConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

            // Configuration Anorder Table By Request EntityFramework
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
        }
        // Configuration DBSet Table

        public DbSet<AreaMaster> areaMasters { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<BankSuports> bankSuports { get; set; }
        public DbSet<CategoryItemMaster> categoryItemMasters { get; set; }
        public DbSet<Citys> citys { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerAddressOrders> customerAddressOrders { get; set; }
        public DbSet<CustomerCart> customerCarts { get; set; }
        public DbSet<CustomerReview> customerReviews { get; set; }
        public DbSet<CustomerWallet> customerWallets { get; set; }
        public DbSet<Districts> districts { get; set; }
        public DbSet<FreeShipProgram> freeShipPrograms { get; set; }
        public DbSet<Gender> genders { get; set; }
        public DbSet<HistoryWallet> historyWallets { get; set; }
        public DbSet<ImageItemMaster> imageItemMasters { get; set; }
        public DbSet<ImageReview> imageReviews { get; set; }
        public DbSet<IssuingCompany> issuingCompanies { get; set; }
        public DbSet<ItemMaster> itemMasters { get; set; }
        public DbSet<Job> jobs { get; set; }
        public DbSet<Marriage> marriages { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<OrdersDetail> ordersDetails { get; set; }
        public DbSet<PairDiscount> pairDiscounts { get; set; }
        public DbSet<PaymentMethods> paymentMethods { get; set; }
        public DbSet<Productsviewedbycustomers> productsviewedbycustomers { get; set; }
        public DbSet<PublishingCompany> publishingCompanies { get; set; }
        public DbSet<QuantityDiscount> quantityDiscounts { get; set; }
        public DbSet<ReceiptPaymentOnline> receiptPaymentOnlines { get; set; }
        public DbSet<ReceiptStatus> receiptStatuses { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<SatisfactionLevel> satisfactionLevels { get; set; }
        public DbSet<SpecialDiscount> specialDiscounts { get; set; }
        public DbSet<TypeAddress> typeAddresses { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<UserAccount> userAccounts { get; set; }
        public DbSet<UserRole> userRoles { get; set; }

    }
}
