using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWithEFCF2.Models
{
    [Table("Customer")]

    public class Customer
    {
        [Column(TypeName = "Money")]
        public decimal? Balance { get; set; }
        [Index] //Setting Index attribute for this column in database.
        [Required] //Setting not null constraint for this column in database.
        [MaxLength(50)]
        [Column("Cname", TypeName = "Varchar")]
        public string CustomerName { get; set; }
        [StringLength(1000)]
        [Column(TypeName = "Varchar")]
        public string Address { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Custid { get; set; }
        public int Sid { get; set; }
        [ForeignKey("Sid")] //Setting the foreign key column for the table.
        public Supplier Supplier { get; set; }
    }
}