using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstracts;

namespace TeduShop.Model.Models
{
    [Table("PostTags")]
    public class PostTag : Auditable
    {
        [Key]
        [Column(Order = 1)]
        public long PostId { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "varchar")]
        [MaxLength(50)]
        public string TagId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}
