using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetSalesModel.Models
{
    public class Shipping
    {
        [Required]
        [Key]
        public int ShippingId { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string ShippingStatus { get; set; }
        
        public virtual ICollection<Order> Orders { get; set; }
    }
}
