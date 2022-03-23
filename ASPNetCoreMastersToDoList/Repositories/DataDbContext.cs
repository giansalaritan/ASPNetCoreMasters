using DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class DataDbContext : IdentityDbContext<User>
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
    }
}