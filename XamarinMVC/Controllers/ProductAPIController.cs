using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessLayer.Context;
using DataAccessLayer.Models;

namespace XamarinMVC.Controllers
{
    public class ProductAPIController : ApiController
    {
        private DatabaseContext db=new DatabaseContext();

        [HttpGet]
        public List<Product> Showproducts()
        {
            return db.Products.ToList(); 
        }
    }
}
