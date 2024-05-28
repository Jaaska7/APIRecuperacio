using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetSalesModel.Models
{
    public class CreditCard
    {
        [Required]
        [Key]
        public int CreditCardId { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string ExpirationDate { get; set; }

        [Required]
        public string SecurityCode { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}