using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstracts;

namespace TeduShop.Model.Models
{
    [Table("Tags")]
    public class Tag : Auditable
    {
        [Key]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Id { get; set; }

        [MaxLength(256)]
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Type { get; set; }
    }
}
