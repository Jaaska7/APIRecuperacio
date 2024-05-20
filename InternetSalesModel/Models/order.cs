using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetSalesModel.Models
{
    public class Order
    {
        [Required]
        [Key]
        public int OrderNumber { get; set; }    
    }
}