using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetSalesModel.Models
{
    public class Item
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public decimal Price { get; set; }

        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}