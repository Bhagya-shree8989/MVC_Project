using MVCUIDesigning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCUIDesigning.Controllers
{
    public class EmpController : Controller
    {
        [HttpGet]
        public ViewResult AddEmp()
        {
            return View();
        }
        [HttpPost]
        //public ViewResult AddEmp(FormCollection fc)
        //{
        //    ViewData["Id"] = fc["id"];
        //    ViewData["Name"] = fc["name"];
        //    ViewData["Job"] = fc["job"];
        //    ViewData["Salary"] = fc["salary"];
        //    return View("DisplayEmp1");
        //}
        public ViewResult AddEmp(Employee Emp)
        {
           return View("DisplayEmp2", Emp);
        }
        
    }
}