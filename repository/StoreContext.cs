using System;
using domain;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options): base(options){}

        public DbSet<Customer> Customers  { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
