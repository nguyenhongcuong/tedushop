using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstracts;

namespace TeduShop.Model.Models
{
    [Table("MenuGroups")]
    public class MenuGroup : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        public virtual IEnumerable<Menu> Menus { get; set; }
    }
}
