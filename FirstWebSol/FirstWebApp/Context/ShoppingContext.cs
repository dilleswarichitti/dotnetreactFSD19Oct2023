using FirstWebApp.Models;
using Microsoft.EntityFrameworkCore;
using FirstWebApp.Constrollers;
using FirstWebApp.Models;

namespace FirstWebApp.Context
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}
