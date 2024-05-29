using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InternetSalesModel.Models
{
    public class ShoppingCart
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShoppingCartId { get; set; }

        [JsonIgnore]
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}