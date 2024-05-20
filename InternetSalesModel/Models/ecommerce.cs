using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetSalesModel.Models
{
    public class Ecommerce
    {
        [Required]
        [Key]
        public string Name { get; set; }    
        
        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }
    }


}