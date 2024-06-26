using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternetSalesModel.Database;
using InternetSalesModel.Models;

namespace InternetSalesModel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcommerceController : ControllerBase
    {
        private readonly InternetSalesDbContext _context;

        public EcommerceController(InternetSalesDbContext context)
        {
            _context = context;
        }

        // GET: api/Ecommerce
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ecommerce>>> GetEcommerce()
        {
            return await _context.Ecommerce
                                    .Include(e => e.Orders)
                                    .ToListAsync();
        }

        // GET: api/Ecommerce/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ecommerce>> GetEcommerce(int id)
        {
            var ecommerce = await _context.Ecommerce
                                            .Include(e => e.Orders)
                                            .FirstOrDefaultAsync(e => e.EcommerceId == id);

            if (ecommerce == null)
            {
                return NotFound(new { message = "Ecommerce not found" });
            }

            return ecommerce;
        }

        // PUT: api/Ecommerce/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEcommerce(int id, Ecommerce ecommerce)
        {
            if (id != ecommerce.EcommerceId)
            {
                return BadRequest(new { message = "Ecommerce ID mismatch" });
            }

            _context.Entry(ecommerce).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EcommerceExists(id))
                {
                    return NotFound(new { message = "Ecommerce not found" });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ecommerce
        [HttpPost]
        public async Task<ActionResult<Ecommerce>> PostEcommerce(Ecommerce ecommerce)
        {
            _context.Ecommerce.Add(ecommerce);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEcommerce", new { id = ecommerce.EcommerceId }, ecommerce);
        }

        // DELETE: api/Ecommerce/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEcommerce(int id)
        {
            var ecommerce = await _context.Ecommerce
                                            .Include(e => e.Orders)
                                            .FirstOrDefaultAsync(e => e.EcommerceId == id);
            if (ecommerce == null)
            {
                return NotFound(new { message = "Ecommerce not found" });
            }

            _context.Ecommerce.Remove(ecommerce);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EcommerceExists(int id)
        {
            return _context.Ecommerce.Any(e => e.EcommerceId == id);
        }
    }
}
