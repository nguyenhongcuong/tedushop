using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstracts;

namespace TeduShop.Model.Models
{
    [Table("Orders")]
    public class Order : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerAddress { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerEmail { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerMobile { get; set; }

        [Required]
        [MaxLength(500)]
        public string CustomerMessage { get; set; }

        [MaxLength(256)]
        public string PaymentMethod { get; set; }

        public string PaymentStatus { get; set; }

        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
