using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWithEFCF2.Models
{
    [Table("Supplier")] //Specifying Name for the table being created in database.

    public class Supplier
    {
            [Key] //Setting this column as Primary Key column.
            [DatabaseGenerated(DatabaseGeneratedOption.None)] //Setting identity off, so will not autogenerate values.
            public int Sid { get; set; }
            [MaxLength(100)] //Setting MaxLength as 100 for this column.
            [Column("Sname", TypeName = "Varchar")] //Setting column name and data type of the column.
            public string SupplierName { get; set; }
            public ICollection<Customer> Customers { get; set; }
        

    }
}