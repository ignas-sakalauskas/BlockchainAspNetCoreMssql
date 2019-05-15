using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebApplication1.Models
{
    public class CarSalesEntry : IBlock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("CarEntryId")]
        public int CarEntryId { get; set; }
        [ForeignKey("Id")]
        public int? PreviousId { get; set; }
        [Required]
        public string CarNumber { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset TransactionDate { get; set; }
        [Required]
        [ValidateNever]
        public string Hash { get; set; }

        [NotMapped]
        public bool IsValid { get; set; }

        public virtual CarSalesEntry Previous { get; set; }
    }
}
