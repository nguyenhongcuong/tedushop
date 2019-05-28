using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstracts;

namespace TeduShop.Model.Models
{
    [Table("Products")]
    public class Product : Auditable

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        [Column(TypeName = "varchar")]
        public string Alias { get; set; }

        [Required]
        public long CategoryId { get; set; }

        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public double Price { get; set; }

        public double? PromotionPrice { get; set; }

        public int? Warranty { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }
            
        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }
    }
}
