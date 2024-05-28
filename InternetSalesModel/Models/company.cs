using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetSalesModel.Models
{
    public class Company
    {
        [Required]
        [Key]
        public int CompanyId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        public virtual ICollection<Item> Items { get; set; }
    }
}