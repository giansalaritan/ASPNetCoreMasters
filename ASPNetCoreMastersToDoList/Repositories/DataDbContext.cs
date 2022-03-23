using DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class DataDbContext : IdentityDbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        //public List<Item> Items
        //{
        //    get
        //    {
        //        return new List<Item>()
        //        {
        //            new Item { Id = 1, Text = "Item 1" },
        //            new Item { Id = 2, Text = "Item 2" },
        //            new Item { Id = 3, Text = "Item 3" },
        //            new Item { Id = 4, Text = "Item 4" },
        //            new Item { Id = 5, Text = "Item 5" }
        //        };
        //    }
        //}
    }
}