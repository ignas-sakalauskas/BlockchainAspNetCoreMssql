using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class CarEntry : IBlockChain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTimeOffset CreateDate { get; set; }

        public virtual IList<CarSalesEntry> CarSalesEntries { get; set; }
    }
}
