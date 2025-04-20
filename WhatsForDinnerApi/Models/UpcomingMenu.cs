// Models/UpcomingMenu.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsForDinnerApi.Models
{
    [Table("UpcomingMenu")]
    public class UpcomingMenu
    {
        [Key]
        public int Id { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
