using MVCWithEFCF3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithEFCF3.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult Index()
        {
            SchoolDbContext dc = new SchoolDbContext();
            Student s1 = new Student
            {
                Sid = 101,
                StudentName = "Suresh",
                StudentClass = 10,
                Fees = 5000.00f,
                Address = "Ameerpet, Hyderabad"
            };
            Student s2 = new Student
            {
                Sid = 102,
                StudentName = "Ramesh",
                StudentClass = 10,
                Fees = 5000.00f,
                Address = "Jubliee Hills, Hyderabad"
            };
            Student s3 = new Student
            {
                Sid = 103,
                StudentName = "Sravani",
                StudentClass = 10,
                Fees = 5000.00f,
                Address = "Madhapur, Hyderabad"
            };
            Student s4 = new Student
            {
                Sid = 104,
                StudentName = "Ajay",
                StudentClass = 10,
                Fees = 5000.00f,
                Address = "Banjara Hills, Hyderabad"
            };
            dc.Students.Add(s1); dc.Students.Add(s2); dc.Students.Add(s3); dc.Students.Add(s4);
            dc.SaveChanges();
            return View(dc.Students);
        }
    }
}