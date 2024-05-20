using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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


    }
}