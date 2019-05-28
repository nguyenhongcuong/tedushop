using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstracts;

namespace TeduShop.Model.Models
{
    [Table("SupportOnlines")]
    public class SupportOnline : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Department { get; set; }

        [MaxLength(256)]
        public string Skype { get; set; }

        [MaxLength(256)]
        public string Facebook { get; set; }

        [MaxLength(256)]
        public string Mobile { get; set; }

        [MaxLength(256)]
        public string Email { get; set; }

        [MaxLength(256)]
        public string Yahoo { get; set; }

        public int? DisplayOrder { get; set; }
    }
}
