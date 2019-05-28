using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstracts;

namespace TeduShop.Model.Models
{
    [Table("Slides")]
    public class Slide : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public int? DisplayOrder { get; set; }
    }
}
