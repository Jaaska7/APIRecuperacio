using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InternetSalesModel.Models
{
    public class ShoppingCartItem
    {
        [Required]
        public int ShoppingCartId { get; set; }

        [JsonIgnore]
        public virtual ShoppingCart? ShoppingCart { get; set; }

        [Required]
        public int ItemId { get; set; }

        [JsonIgnore]
        public virtual Item? Item { get; set; }

        public int Quantity { get; set; }
    }
}
