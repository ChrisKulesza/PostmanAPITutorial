using Microsoft.EntityFrameworkCore;
using PostmanAPI.Models;

namespace PostmanAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
