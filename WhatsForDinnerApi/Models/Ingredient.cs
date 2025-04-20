// Models/Ingredient.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsForDinnerApi.Models
{
    [Table("Ingredients")]
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DishIngredient>? DishIngredients { get; set; }
    }
}
