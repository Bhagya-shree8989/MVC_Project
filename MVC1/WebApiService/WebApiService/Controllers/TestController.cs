using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiService.Controllers
{
    public class TestController : ApiController
    {
        static List<string> Colors = new List<string>
        {
            "Red","Blue","Green","Purple","Magenta"
        };
        public IEnumerable<string>Get()
        {
            return Colors;
        }
        public string Get(int id)
        {
            return Colors[id];
        }
        public void Post([FromBody] string color)
        {
           Colors.Add(color);
        }
        public void Put(int id,[FromBody] string color)
        {
            Colors[id]=color;
        }
        public void Delete(int id)
        {
            Colors.RemoveAt(id);
        }
    }
}
