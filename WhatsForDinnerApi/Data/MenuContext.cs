// Data/MenuContext.cs
using Microsoft.EntityFrameworkCore;
using WhatsForDinnerApi.Models;

namespace WhatsForDinnerApi.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options)
            : base(options)
        { }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<UpcomingMenu> UpcomingMenu { get; set; }

        public DbSet<GroceryItem> GroceryItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // composite PK on the join table
            modelBuilder.Entity<DishIngredient>()
                .HasKey(di => new { di.DishId, di.IngredientId });

            // explicitly map tables
            modelBuilder.Entity<Dish>().ToTable("Dishes");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredients");
            modelBuilder.Entity<DishIngredient>().ToTable("DishIngredients");
            modelBuilder.Entity<UpcomingMenu>().ToTable("UpcomingMenu");
        }
    }
}
