using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstracts;

namespace TeduShop.Model.Models
{
    [Table("OrderDetails")]
    public class OrderDetail : Auditable
    {
        [Key]
        [Column(Order = 1)]
        public long OrderId { get; set; }

        [Key]
        [Column(Order =  2)]
        public long ProductId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
