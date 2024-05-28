using System.ComponentModel.DataAnnotations;

namespace InternetSalesModel.Models
{
    public class OrderItem
    {
        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Required]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }

        // The price of the item at the time of the order
        public decimal Price { get; set; } = 0;

        [Required]
        public int Quantity { get; set; } 
    }
}