using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstracts;

namespace TeduShop.Model.Models
{
    [Table("ProductTags")]
    public class ProductTag : Auditable
    {
        [Key]
        [Column(Order = 1)]
        public long ProductId { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "varchar")]
        [MaxLength(50)]
        public string TagId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}
