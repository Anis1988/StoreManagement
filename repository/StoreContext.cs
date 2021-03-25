using System;
using domain;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options): base(options){}

        public DbSet<Class1> stores { get; set; }
    }
}
