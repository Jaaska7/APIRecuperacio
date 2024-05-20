using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetSalesModel.Models
{
    public class Order
    {
        [Required]
        public int OrderNumber { get; set; }    
    }
}