using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternetSalesModel.Database;
using InternetSalesModel.Models;

namespace InternetSalesModel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartItemsController : ControllerBase
    {
        private readonly InternetSalesDbContext _context;

        public ShoppingCartItemsController(InternetSalesDbContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingCartItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCartItem>>> GetShoppingCartItems()
        {
            return await _context.ShoppingCartItems.ToListAsync();
        }

        // GET: api/ShoppingCartItems/5
        [HttpGet("{shoppingCartId}/{itemId}")]
        public async Task<ActionResult<ShoppingCartItem>> GetShoppingCartItem(int shoppingCartId, int itemId)
        {
            var shoppingCartItem = await _context.ShoppingCartItems.FirstOrDefaultAsync(ci => ci.ShoppingCartId == shoppingCartId && ci.ItemId == itemId);

            if (shoppingCartItem == null)
            {
                return NotFound();
            }

            return shoppingCartItem;
        }

        // PUT: api/ShoppingCartItems/5
        [HttpPut("{shoppingCartId}/{itemId}")]
        public async Task<IActionResult> PutShoppingCartItem(int shoppingCartId, int itemId, ShoppingCartItem shoppingCartItem)
        {
            if (shoppingCartId != shoppingCartItem.ShoppingCartId || itemId != shoppingCartItem.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(shoppingCartItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingCartItemExists(shoppingCartId, itemId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShoppingCartItems
        [HttpPost]
        public async Task<ActionResult<ShoppingCartItem>> PostShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            _context.ShoppingCartItems.Add(shoppingCartItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShoppingCartItemExists(shoppingCartItem.ShoppingCartId, shoppingCartItem.ItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShoppingCartItem", new { shoppingCartId = shoppingCartItem.ShoppingCartId, itemId = shoppingCartItem.ItemId }, shoppingCartItem);
        }

        // DELETE: api/ShoppingCartItems/5
        [HttpDelete("{shoppingCartId}/{itemId}")]
        public async Task<IActionResult> DeleteShoppingCartItem(int shoppingCartId, int itemId)
        {
            var shoppingCartItem = await _context.ShoppingCartItems.FirstOrDefaultAsync(ci => ci.ShoppingCartId == shoppingCartId && ci.ItemId == itemId);
            if (shoppingCartItem == null)
            {
                return NotFound();
            }

            _context.ShoppingCartItems.Remove(shoppingCartItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShoppingCartItemExists(int shoppingCartId, int itemId)
        {
            return _context.ShoppingCartItems.Any(e => e.ShoppingCartId == shoppingCartId && e.ItemId == itemId);
        }
    }
}
