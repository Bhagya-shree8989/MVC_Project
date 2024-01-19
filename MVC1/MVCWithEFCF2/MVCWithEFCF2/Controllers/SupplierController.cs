using MVCWithEFCF2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithEFCF2.Controllers
{
    public class SupplierController : Controller
    {
        
        CompanyDbContext dc = new CompanyDbContext();
        public ActionResult Index()
        {
            Supplier s1 = new Supplier { Sid = 101, SupplierName = "Ashok Distributors." };
            Supplier s2 = new Supplier { Sid = 102, SupplierName = "Meghna Distributors." };
            Supplier s3 = new Supplier { Sid = 103, SupplierName = "Diamond Distributors." };
            Supplier s4 = new Supplier { Sid = 104, SupplierName = "Prasad Distributors." };
            dc.Suppliers.Add(s1); dc.Suppliers.Add(s2);
            dc.Suppliers.Add(s3); dc.Suppliers.Add(s4);
            dc.SaveChanges();
            return View(dc.Suppliers);
        }
    }
}