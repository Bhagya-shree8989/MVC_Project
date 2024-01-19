using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWithEFCF3.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Sid { get; set; }
        [Required]
        [MaxLength(100)]
        [Column("Sname", TypeName = "Varchar")]
        public string StudentName { get; set; }
        [Column("Class")]
        public byte StudentClass { get; set; }
        [MaxLength(1000)]
        [Column(TypeName = "Varchar")]
        public string Address { get; set; }
        public float Fees { get; set; }
    }
}