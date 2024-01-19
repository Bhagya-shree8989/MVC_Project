using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MVCFilters.Models;

namespace MVCFilters.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        MVCDBEntities dc = new MVCDBEntities();
        #region ChildActionOnly Filter

        public ViewResult DisplayDepts()
        {
            return View(dc.Departments);
        }
        [ChildActionOnly]
        public ViewResult DisplayEmpsByDept(int id)
        {
            var Emps = from E in dc.Employees where E.Did == id select E;
            return View(Emps);
        }
      
     
        #endregion

        #region OutpurCache Filter
        public ViewResult DisplayCustomers1()
        {
            return View(dc.Customers);
        }
        [OutputCache(Duration =30,Location =OutputCacheLocation.Server)]
        public ViewResult DisplayCustomers2() 
        {
            return View(dc.Customers);
        }
        [OutputCache(Duration =30, Location =OutputCacheLocation.Server,VaryByParam ="City")]
        public ViewResult DisplayCustomers3(string City)
        {
          return View(from C in dc.Customers where C.City==City select C);
        }
        [OutputCache(Duration =30,Location =OutputCacheLocation.Server,VaryByCustom ="browser")]
        public ViewResult DisplayCustomers4()
        {
            return View(dc.Customers);
        }

        [OutputCache(CacheProfile ="MyCacheProfile")]
        public ViewResult DisplayCustomers5()
        {
            return View(dc.Customers);
        }
        #endregion
        #region ValidateInput Filter
        public ViewResult GetComments()
        {
            return View();
        }
        [HttpPost,ValidateInput(false)]
        public string GetComments(string txtComments)
        {
            return txtComments;
        }
        #endregion
        #region ValidateAntiForgeryToken Filter
        public ViewResult AddEmployee()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public string AddEmployee(Employee Emp)
        {
            Emp.Status = true;
            dc.Employees.Add(Emp);
            dc.SaveChanges();
            return "Record Inserted";
        }
        #endregion
        #region HandleError Filter
        public ViewResult DivideNums()
        {
            return View();
        }
        [HttpPost,HandleError]
        public string DivideNums(int num1, int num2)
        {
            int result = num1 / num2;
            return "Result is: " + result;
        }
        #endregion
        [HandleError]
        public ViewResult ShowView()
        {
            return View();
        }
    }
}