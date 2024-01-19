using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCURD.Models
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publication { get; set; }
        public  int Year { get; set; }
    }
}