using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatsForDinnerApi.Data;
using WhatsForDinnerApi.Models;

namespace WhatsForDinnerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroceryListController : ControllerBase
    {
        private readonly MenuContext _context;

        public GroceryListController(MenuContext context)
        {
            _context = context;
        }

        // GET: api/grocerylist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroceryItem>>> GetGroceryItems()
        {
            return await _context.GroceryItems.ToListAsync();
        }

        // POST: api/grocerylist
        [HttpPost]
        public async Task<ActionResult<GroceryItem>> AddGroceryItem(GroceryItem item)
        {
            _context.GroceryItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGroceryItems), new { id = item.Id }, item);
        }

        // DELETE: api/grocerylist/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroceryItem(int id)
        {
            var item = await _context.GroceryItems.FindAsync(id);
            if (item == null) return NotFound();

            _context.GroceryItems.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
