using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWithEFCF4.Models
{
    public class Student:Person
    {
        public int Class { get; set; }
        public float Marks { get; set; }
        public float Fees { get; set; }
    }
}