using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetSalesModel.Models
{
    public class Shipping
    
    {
        [Required]
        [Key]
        public string Name { get; set; }    
        
        [Required]
        public string ShippingStatus { get; set;}
    }
}