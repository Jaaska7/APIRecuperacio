using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetSalesModel.Models
{
    public class ShoppingCartItem
    {
        [Required]
        public int ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        [Required]
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
        public int Quantity { get; internal set; }
    }
}