using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TeduShop.Model.Abstracts;

namespace TeduShop.Model.Models
{
    [Table("VisitorStatistics")]
    public class VisitorStatistic : Auditable
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime VisitedDate { get; set; }

        [Required]
        [MaxLength(256)]
        public string IpAddress { get; set; }
    }
}
