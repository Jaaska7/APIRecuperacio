using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternetSalesModel.Database;
using InternetSalesModel.Models;

public class ItemStats
{
    public int TotalQuantity { get; set; }
    public decimal TotalSales { get; set; }
}


namespace InternetSalesModel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly InternetSalesDbContext _context;

        public OrderItemsController(InternetSalesDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            return await _context.OrderItems.ToListAsync();
        }

        // GET: api/OrderItems/5
        [HttpGet("{orderId}/{itemId}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int orderId, int itemId)
        {
            var orderItem = await _context.OrderItems.FindAsync(orderId, itemId);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }

        // PUT: api/OrderItems/5/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{orderId}/{itemId}")]
        public async Task<IActionResult> PutOrderItem(int orderId, int itemId, OrderItem orderItem)
        {
            if (orderId != orderItem.OrderId || itemId != orderItem.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(orderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(orderId, itemId))
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

        // POST: api/OrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrderItemExists(orderItem.OrderId, orderItem.ItemId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOrderItem", new { orderId = orderItem.OrderId, itemId = orderItem.ItemId }, orderItem);
        }

        // DELETE: api/OrderItems/5/5
        [HttpDelete("{orderId}/{itemId}")]
        public async Task<IActionResult> DeleteOrderItem(int orderId, int itemId)
        {
            var orderItem = await _context.OrderItems.FindAsync(orderId, itemId);
            if (orderItem == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderItemExists(int orderId, int itemId)
        {
            return _context.OrderItems.Any(e => e.OrderId == orderId && e.ItemId == itemId);
        }

        // PUT: api/OrderItems/{orderId}/{itemId}/5
        [HttpPut("{orderId}/{itemId}/{quantity}")]
        public async Task<IActionResult> UpdateOrderItemQuantity(int orderId, int itemId, int quantity)
        {
            var orderItem = await _context.OrderItems.FindAsync(orderId, itemId);
            if (orderItem == null)
            {
                return NotFound();
            }

            orderItem.Quantity = quantity;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(orderId, itemId))
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

        // GET: api/OrderItems/GetItemStats/5
        [HttpGet("GetItemStats/{itemId}")]
        public async Task<ActionResult<ItemStats>> GetItemStats(int itemId)
        {
            var itemStats = await _context.OrderItems
                .Where(oi => oi.ItemId == itemId)
                .Select(oi => new { Quantity = oi.Quantity, Price = oi.Price })
                .ToListAsync();

            if (itemStats == null || itemStats.Count == 0)
            {
                return NotFound();
            }

            int totalQuantity = itemStats.Sum(stat => stat.Quantity);
            decimal totalSales = itemStats.Sum(stat => stat.Quantity * stat.Price);

            var stats = new ItemStats
            {
                TotalQuantity = totalQuantity,
                TotalSales = totalSales
            };

            return stats;
        }

    }
}
