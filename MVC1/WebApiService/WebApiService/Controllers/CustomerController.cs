using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiService.Models;

namespace WebApiService.Controllers
{
    public class CustomerController : ApiController
    {
        MVCDBEntities dc = new MVCDBEntities();
        public List<Customer>Get()
        {
            return dc.Customers.ToList();
        }
        public Customer Get(int id)
        {
            return dc.Customers.Find(id);
        }
        public HttpResponseMessage Post(Customer c)
        {
            try
            {
                c.Status = true;
                dc.Customers.Add(c);
                dc.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            catch (Exception )
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }
        public HttpResponseMessage Put(Customer c)
        {
            try
            {
                Customer obj = dc.Customers.Find(c.custid);
                if(obj==null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                obj.Name = c.Name;
                obj.Balance = c.Balance;
                obj.City = c.City;
                dc.Entry(obj).State = EntityState.Modified;
                dc.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception )
            {
              throw new HttpResponseException (HttpStatusCode.InternalServerError);
            }
        }
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                Customer obj = dc.Customers.Find(id);
                if(obj==null)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
                obj.Status = false;
                dc.Entry(obj).State = EntityState.Modified;
                dc.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception )
            {
                throw new HttpResponseException (HttpStatusCode.InternalServerError);
            }
        }
    }
}
