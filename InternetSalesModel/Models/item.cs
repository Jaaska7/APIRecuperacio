using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetSalesModel.Models
{
    public class Item
    {
        [Required]
        [Key]
        public string Name { get; set; }    
        
        [Required]
        public decimal Price { get; set; }
    }
}