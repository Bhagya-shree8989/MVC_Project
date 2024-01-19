using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTestProject2.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public string Index()
        {
            return "Hello from Demo Controller-Index Action Method.";
        }
        public string Show()
        {
            return "Hello from Demo Controller-Show Action Method.";
        }
    }
}