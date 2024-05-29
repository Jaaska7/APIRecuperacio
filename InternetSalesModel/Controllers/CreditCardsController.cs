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
    public class CreditCardsController : ControllerBase
    {
        private readonly InternetSalesDbContext _context;

        public CreditCardsController(InternetSalesDbContext context)
        {
            _context = context;
        }

        // GET: api/CreditCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditCard>>> GetCreditCards()
        {
            return await _context.CreditCards
                                    .Include(cc => cc.Customer)
                                    .ToListAsync();
        }

        // GET: api/CreditCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreditCard>> GetCreditCard(int id)
        {
            var creditCard = await _context.CreditCards
                                            .Include(cc => cc.Customer)
                                            .FirstOrDefaultAsync(cc => cc.CreditCardId == id);

            if (creditCard == null)
            {
                return NotFound(new { message = "Credit card not found" });
            }

            return creditCard;
        }

        // PUT: api/CreditCards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreditCard(int id, CreditCard creditCard)
        {
            if (id != creditCard.CreditCardId)
            {
                return BadRequest(new { message = "Credit card ID mismatch" });
            }

            _context.Entry(creditCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditCardExists(id))
                {
                    return NotFound(new { message = "Credit card not found" });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CreditCards
        [HttpPost]
        public async Task<ActionResult<CreditCard>> PostCreditCard(CreditCard creditCard)
        {
            _context.CreditCards.Add(creditCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCreditCard", new { id = creditCard.CreditCardId }, creditCard);
        }

        // DELETE: api/CreditCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreditCard(int id)
        {
            var creditCard = await _context.CreditCards
                                            .Include(cc => cc.Customer)
                                            .FirstOrDefaultAsync(cc => cc.CreditCardId == id);
            if (creditCard == null)
            {
                return NotFound(new { message = "Credit card not found" });
            }

            _context.CreditCards.Remove(creditCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CreditCardExists(int id)
        {
            return _context.CreditCards.Any(e => e.CreditCardId == id);
        }
    }
}
