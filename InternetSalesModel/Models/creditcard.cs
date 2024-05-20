using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetSalesModel.Models
{
    public class CreditCard
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string ExpirationDate { get; set; }

        [Required]
        public string SecurityCode { get; set; }

    }
}