using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstracts;

namespace TeduShop.Model.Models
{
    [Table("Footers")]
    public class Footer : Auditable
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
