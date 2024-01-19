using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWithEFCF4.Models
{
    public class SchoolDbContext:DbContext
    {
        public SchoolDbContext() : base("ConStr")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<SchoolDbContext>());
        }
        public DbSet<Person> People { get; set; }
    }
}