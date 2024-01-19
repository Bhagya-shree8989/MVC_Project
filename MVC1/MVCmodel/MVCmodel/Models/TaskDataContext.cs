using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace MVCmodel.Models
{
    public class TaskDataContext:DataContext
    {
         public TaskDataContext(string connection) : base(connection) { }

         public Table<Task> Tasks => GetTable<Task>();
        

    }
}