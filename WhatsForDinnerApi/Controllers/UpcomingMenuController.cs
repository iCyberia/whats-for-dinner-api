using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatsForDinnerApi.Data;
using WhatsForDinnerApi.Models;

namespace WhatsForDinnerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpcomingMenuController : ControllerBase
    {
        private readonly MenuContext _context;
        public UpcomingMenuController(MenuContext ctx) => _context = ctx;

        // GET: api/upcomingmenu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetUpcomingMenu()
        {
            var upcoming = await _context.UpcomingMenu
                .Include(u => u.Dish)
                    .ThenInclude(d => d.DishIngredients)
                        .ThenInclude(di => di.Ingredient)
                .ToListAsync();

            // Flatten output to avoid circular reference issues
            var result = upcoming.Select(u => new
            {
                u.Id,
                Dish = new
                {
                    u.Dish.Id,
                    u.Dish.Name,
                    u.Dish.ImageUrl,
                    u.Dish.Price,
                    DinnerIngredients = u.Dish.DishIngredients.Select(di => new
                    {
                        IngredientName = di.Ingredient.Name,
                        Quantity = di.Quantity,
                        Unit = di.QuantityType
                    })
                }
            });

            return Ok(result);
        }

        // POST: api/upcomingmenu/{dishId}
        [HttpPost("{dishId}")]
        public async Task<IActionResult> AddToUpcomingMenu(int dishId)
        {
            var dish = await _context.Dishes.FindAsync(dishId);
            if (dish == null) return NotFound("Dish not found");

            var item = new UpcomingMenu { DishId = dishId };
            _context.UpcomingMenu.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item);
        }

        // DELETE: api/upcomingmenu/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var item = await _context.UpcomingMenu.FindAsync(id);
            if (item == null) return NotFound();
            _context.UpcomingMenu.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // GET: api/upcomingmenu/grocerylist
        [HttpGet("grocerylist")]
        public async Task<ActionResult<IEnumerable<object>>> GetGroceryList()
        {
            var ingredients = await _context.UpcomingMenu
                .Include(u => u.Dish)
                    .ThenInclude(d => d.DishIngredients)
                        .ThenInclude(di => di.Ingredient)
                .SelectMany(u => u.Dish.DishIngredients)
                .GroupBy(di => new { di.Ingredient.Name, di.QuantityType })
                .Select(g => new
                {
                    Name = g.Key.Name,
                    Quantity = g.Sum(di => di.Quantity),
                    Unit = g.Key.QuantityType
                })
                .ToListAsync();

            return Ok(ingredients);
        }
    }
}
