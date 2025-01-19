using Microsoft.EntityFrameworkCore;
using VideoShopRentalAPI.Models;

namespace VideoShopRentalAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<RentalHeader> RentalHeaders { get; set; }
    }
}
