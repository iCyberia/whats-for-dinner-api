using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsForDinnerApi.Models
{
    public class DishIngredient
    {
        [NotMapped]
        public int Id { get; set; }

        public double Quantity { get; set; }   // ← match SQL double
        public string QuantityType { get; set; } // box, cups, etc.

        public int DishId { get; set; }
        public Dish Dish { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

    }
}
