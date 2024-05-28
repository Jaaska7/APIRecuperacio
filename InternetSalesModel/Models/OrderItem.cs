using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetSalesModel.Models
{
    public class OrderItem
    {
        [Required]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }

        [Required]
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}