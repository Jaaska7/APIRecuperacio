using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace InternetSalesModel.Models
{
    public class Company
    {
        [Required]
        [Key]
        public int CompanyId { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]

        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    }
}