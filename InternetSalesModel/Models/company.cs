using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetSalesModel.Models
{
    public class Company
    {
        [Required]
        [Key]
        public string Name { get; set; }
    }
}