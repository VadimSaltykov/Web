using Domain.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace WebUI.Controllers
{
    public class WebApiController : ApiController
    {
        EFDbContext db = new EFDbContext();

        // GET: api/WebApi
        public IEnumerable<Book> GetBooks()
        {
            return db.Books;
        }

        // GET: api/WebApi/5
        [System.Web.Http.HttpGet]
        public Book GetBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No product with ID = {0}", id)),
                    ReasonPhrase = "Product ID Not Found"
                };
                throw new HttpResponseException(resp);
            }
            return book;
        }

        [System.Web.Http.HttpPost]
        public HttpResponseMessage CreateBook([FromBody] Book book)
        {
            if (book == null)
                return Request.CreateResponse<Book>(HttpStatusCode.BadRequest, book);
            db.Books.Add(book);
            db.SaveChanges();
            return Request.CreateResponse<Book>(HttpStatusCode.Created, book);
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult EditBook(int id, [FromBody] Book book)
        {
            if (book == null)
                return BadRequest();
            if (id != book.BookId)
                return NotFound();

            if (id == book.BookId)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }
            return Ok(book);
        }

        // DELETE: api/WebApi/5
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
                return NotFound();
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
            return Ok(book);
        }
    }
}
