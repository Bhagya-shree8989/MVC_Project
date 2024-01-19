using MVCWithLinq4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithLinq4.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDAL obj = new EmployeeDAL();
        public ViewResult DisplayEmployees()
        {
            return View(obj.GetEmployees());
        }
        public ViewResult DisplayEmployee(int eid)
        {
            return View(obj.GetEmployee(eid));
        }
        [HttpGet]
        public ViewResult AddEmployee()
        {
            EmpDept emp = new EmpDept();
            emp.Departments = obj.GetDepartments();
            return View(emp);
        }
        [HttpPost]
        public RedirectToRouteResult AddEmployee(EmpDept emp)
        {
            obj.Employee_Insert(emp);
            return RedirectToAction("DisplayEmployees");
        }
        public ViewResult EditEmployee                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              (int eid)
        {
            EmpDept Emp = obj.GetEmployee(eid);
            Emp.Departments = obj.GetDepartments();
            return View(Emp);
        }
        public RedirectToRouteResult UpdateEmployee(EmpDept emp)
        {
            obj.Employee_Update(emp);
            return RedirectToAction("DisplayEmployees");
        }
        public RedirectToRouteResult DeleteEmployee(int eid)
        {
            obj.Employee_Delete(eid);
            return RedirectToAction("DisplayEmployee");
        }
    }
}