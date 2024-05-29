using Microsoft.EntityFrameworkCore;
using InternetSalesModel.Models;


namespace InternetSalesModel.Database
{
    public class InternetSalesDbContext : DbContext
    {
        public InternetSalesDbContext(DbContextOptions<InternetSalesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ecommerce> Ecommerce { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Company
            modelBuilder.Entity<Company>()
                .HasKey(c => c.CompanyId);

            modelBuilder.Entity<Company>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Company)
                .HasForeignKey(i => i.CompanyId);

            // CreditCard
            modelBuilder.Entity<CreditCard>()
                .HasKey(cc => cc.CreditCardId);

            modelBuilder.Entity<CreditCard>()
                .Property(cc => cc.CardNumber)
                .IsRequired();

            modelBuilder.Entity<CreditCard>()
                .Property(cc => cc.ExpirationDate)
                .IsRequired();

            modelBuilder.Entity<CreditCard>()
                .Property(cc => cc.SecurityCode)
                .IsRequired();

            modelBuilder.Entity<CreditCard>()
                .HasOne(cc => cc.Customer)
                .WithOne(c => c.CreditCard)
                .HasForeignKey<CreditCard>(cc => cc.CustomerId);

            // Customer
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.Address)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.Email)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            // Ecommerce
            modelBuilder.Entity<Ecommerce>()
                .HasKey(e => e.EcommerceId);

            modelBuilder.Entity<Ecommerce>()
                .Property(e => e.Name)
                .IsRequired();

            modelBuilder.Entity<Ecommerce>()
                .Property(e => e.Address)
                .IsRequired();

            modelBuilder.Entity<Ecommerce>()
                .Property(e => e.Email)
                .IsRequired();

            modelBuilder.Entity<Ecommerce>()
                .HasMany(e => e.Orders)
                .WithOne();

            // Item
            modelBuilder.Entity<Item>()
                .HasKey(i => i.ItemId);

            modelBuilder.Entity<Item>()
                .Property(i => i.Name)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(i => i.Price)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .HasMany(i => i.OrderItems)
                .WithOne(oi => oi.Item)
                .HasForeignKey(oi => oi.ItemId);

            modelBuilder.Entity<Item>()
                .HasMany(i => i.ShoppingCartItems)
                .WithOne(sci => sci.Item)
                .HasForeignKey(sci => sci.ItemId);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Company) 
                .WithMany(c => c.Items) 
                .HasForeignKey(i => i.CompanyId); 

            // Order
            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderNumber)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId);

            // Shipping
            modelBuilder.Entity<Shipping>()
                .HasKey(s => s.ShippingId);

            modelBuilder.Entity<Shipping>()
                .Property(s => s.Name)
                .IsRequired();

            modelBuilder.Entity<Shipping>()
                .Property(s => s.ShippingStatus)
                .IsRequired();

            modelBuilder.Entity<Shipping>()
                .HasMany(s => s.Orders)
                .WithOne();

            // ShoppingCart
            modelBuilder.Entity<ShoppingCart>()
                .HasKey(sc => sc.ShoppingCartId);

            modelBuilder.Entity<ShoppingCart>()
                .HasMany(sc => sc.ShoppingCartItems)
                .WithOne(sci => sci.ShoppingCart)
                .HasForeignKey(sci => sci.ShoppingCartId);

            // OrderItem (Many-to-Many relationship between Order and Item)
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ItemId });

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Item)
                .WithMany(i => i.OrderItems)
                .HasForeignKey(oi => oi.ItemId);

            // ShoppingCartItem (Many-to-Many relationship between ShoppingCart and Item)
            modelBuilder.Entity<ShoppingCartItem>()
                .HasKey(sci => new { sci.ShoppingCartId, sci.ItemId });

            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(sci => sci.ShoppingCart)
                .WithMany(sc => sc.ShoppingCartItems)
                .HasForeignKey(sci => sci.ShoppingCartId);

            modelBuilder.Entity<ShoppingCartItem>()
                .HasOne(sci => sci.Item)
                .WithMany(i => i.ShoppingCartItems)
                .HasForeignKey(sci => sci.ItemId);
        }
    }
}