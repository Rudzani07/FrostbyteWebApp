using FrostbyteWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FrostbyteWebApp.Data.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);
            //add
            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var client = new IdentityRole("client");
            client.NormalizedName = "client";

            var PurchasingManager = new IdentityRole("PurchaseManager");
            PurchasingManager.NormalizedName = "PurchasingManager";

            var InventoryLiaison = new IdentityRole("InventoryLiaison");
            InventoryLiaison.NormalizedName = "InventoryLiaison";

            var supplier = new IdentityRole("supplier");
            supplier.NormalizedName = "supplier";

            Builder.Entity<IdentityRole>().HasData(admin, client, PurchasingManager, InventoryLiaison, supplier);

        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<PurchasingManager> PurchasingManagers { get; set; }
        public virtual DbSet<InventoryLiaison> InventoryLiaisons { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<UserBank> Banks1 { get; set; }
        public virtual DbSet<DeliveryNote> DeliveryNotes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PmRequestForQoutation> PmrequestForQoutations { get; set; }
        public virtual DbSet<SendDeliveryNote> SendDeliveryNotes { get; set; }

        public virtual DbSet<SendOrder> SendOrders { get; set; }
        public virtual DbSet<SendPmRequestForQuotation> SendPmrequestForQuotations { get; set; }

        public virtual DbSet<SendPurchasingRequest> SendPurchasingRequests { get; set; }
        public virtual DbSet<SendPmRequestForQuotation> SendRequestForQuotations { get; set; }

        public virtual DbSet<UserType> UserTypes { get; set; }

        public virtual DbSet<SupplierRequestForQoutation> SupplierRequestForQuotations { get; set; }

        public virtual DbSet<SendSupplierRequestForQuotation> SendSupplierRequestForQuotations { get; set; }
        public DbSet<FrostbyteWebApp.Models.PurchasingRequest> PurchasingRequest { get; set; } = default!;
    }
}







       

        

        
