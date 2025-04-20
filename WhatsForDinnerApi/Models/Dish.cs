// Dish.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsForDinnerApi.Models
{
    [Table("Dishes")]
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public double Price { get; set; }

        // nav to the join‑table
        public List<DishIngredient> DishIngredients { get; set; } = new();
    }
}
