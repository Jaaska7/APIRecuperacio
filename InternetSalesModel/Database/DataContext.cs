using Microsoft.EntityFrameworkCore;
using InternetSalesModel.Models;
using System;

namespace InternetSalesModel.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Company> Companys { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ecommerce> Ecommerces { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        
    }
}