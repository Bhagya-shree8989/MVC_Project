using MVCWithEFCF4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithEFCF4.Controllers
{
    public class SchoolController : Controller
    {
        SchoolDbContext dc = new SchoolDbContext();
        public ActionResult Index()
        {
            Student s1 = new Student
            {
                Name = "Rajesh",
                Phone = "23746666",
                Address = "Pune",
                Class = 10,
                Marks = 450.00f,
                Fees = 5000.00f
            };
            Student s2 = new Student
            {
                Name = "Ajay",
                Phone = "23747777",
                Address = "Mumbai",
                Class = 10,
                Marks = 450.00f,
                Fees = 5000.00f
            };
            Student s3 = new Student
            {
                Name = "Venkat",
                Phone = "23748888",
                Address = "Delhi",
                Class = 10,
                Marks = 450.00f,
                Fees = 5000.00f
            };
            Teacher t1 = new Teacher
            {
                Name = "Raju",
                Phone = "23741234",
                Address = "Delhi",
                Designation = "Lecturer",
                Salary = 25000.00,
                Subject = "Physics"
            };
            Teacher t2 = new Teacher
            {
                Name = "Suresh",
                Phone = "23745678",
                Address = "Delhi",
                Designation = "Lecturer",
                Salary = 25000.00,
                Subject = "Maths"
            };
            Teacher t3 = new Teacher
            {
                Name = "Rahul",
                Phone = "23747890",
                Address = "Delhi",
                Designation = "Lecturer",
                Salary = 25000.00,
                Subject = "Chemistry"
            };
            dc.People.Add(s1); dc.People.Add(s2); dc.People.Add(s3);
            dc.People.Add(t1); dc.People.Add(t2); dc.People.Add(t3);
            dc.SaveChanges();
            return View();
        }
        public ViewResult DisplayPeople()
        {
            var People = from S in dc.People select S;
            return View(People);
        }
        public ViewResult DisplayStudents()
        {
            var Students = from S in dc.People.OfType<Student>() select S;
            return View(Students);
        }
        public ViewResult DisplayTeachers()
        {
            var Teachers = from S in dc.People.OfType<Teacher>() select S;
            return View(Teachers);
        }

    }
}