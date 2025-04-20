// Controllers/MealsController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatsForDinnerApi.Data;
using WhatsForDinnerApi.Models;

namespace WhatsForDinnerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealsController : ControllerBase
    {
        private readonly MenuContext _context;
        public MealsController(MenuContext context) => _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Dish>> Get()
            => Ok(_context.Dishes.Include(d => d.DishIngredients).ToList());
    }
}
