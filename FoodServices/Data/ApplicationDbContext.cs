using Microsoft.EntityFrameworkCore;
using FoodServices.Models;
using FoodServices.Models.Cascade;

namespace FoodServices.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<MenuItem> Menu { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<OrderAnyItem> OrderAnyItem { get; set; }



        //public DbSet<MainCategory> MainCategories { get; set; }

        //public DbSet<MainItems> MainItems { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        public DbSet<FoodServices.Models.Customer> Customer { get; set; }
    }
}
