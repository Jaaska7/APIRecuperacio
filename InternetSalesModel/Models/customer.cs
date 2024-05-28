using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetSalesModel.Models
{
    public class Customer
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        public virtual CreditCard CreditCard { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
