using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Web_Api_EF.Models;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Web_Api_EF.Controllers
{
    public class ProductController : ApiController
    {
        private infiniteEntities db = new infiniteEntities();

        public IQueryable<tblproduct> Getproducts()
        {
            return db.tblproducts;
        }

        [ResponseType(typeof(tblproduct))]

        public IHttpActionResult GetProduct(int id)
        {
            tblproduct product=db.tblproducts.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id,tblproduct product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Entry(product).State=System.Data.Entity.EntityState.Modified;
            try
            {
                db.SaveChanges();

            }
            catch(DbUpdateConcurrencyException ex)
            {
               
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        //our own post
        [HttpPost]
        public IHttpActionResult PostNewProduct([FromBody]tblproduct product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Validation Failed");
            }
            db.tblproducts.Add(product);
            db.SaveChanges();
            return Ok("Success");
        }

        [ResponseType(typeof(tblproduct))]
        public IHttpActionResult DeleteProduct(int id)
        {
            tblproduct product = db.tblproducts.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            db.tblproducts.Remove(product);
            db.SaveChanges();
            return Ok(product);
        }
    }
}
