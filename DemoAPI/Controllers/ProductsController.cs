using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class ProductsController : ApiController
    {
        List<Product> Products = new List<Product>(new Product[] {
            new Product { ID = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { ID = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { ID = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        });

        public IEnumerable<Product> GetAllProducts()
        {
            return Products;
        }

        public IHttpActionResult GetProduct(int ID)
        {
            var oProduct = Products.FirstOrDefault(p => p.ID == ID);
            if (oProduct == null) return NotFound();
            return Ok(oProduct);
        }

        //HTTP Vrbs
        //GetAll() --Get Obtiene elementos
        
        //GetById(object Id) --Get Optiene elemento por su ID
        
        //PutPerson(object Id,Person obj) --Put Actualiza el elemento por su ID

        //PostPerson(Person obj) --Post Agrega un nuevo elemento.

        //DeletePerson(object ID) --Delete Elimina el elemento
    }
}
