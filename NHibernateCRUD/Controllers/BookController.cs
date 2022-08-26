using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernateCRUD.Context;
using NHibernateCRUD.Model;
using Serilog;

namespace NHibernateCRUD.Controllers
{
    [ApiController]
    [Route("api/nhibernate/[controller]")]
    public class BookContoller : ControllerBase
    {
        private readonly IMapperSession session;
        public BookContoller(IMapperSession session)
        {
            this.session = session;
        }

        [HttpGet]
        public List<Book> Get()
        {
            List<Book> result = session.Books.ToList();
            return result;
        }


        [HttpGet("{id}")]
        public Book Get(int id)
        {
            Book result = session.Books.Where(x => x.id == id).FirstOrDefault();
            return result;
        }

        [HttpPost]
        public void Post([FromBody] Book book)
        {
            try
            {
                session.BeginTransaction();
                session.Save(book);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, "Book Insert Error");
            }
            finally
            {
                session.CloseTransaction();
            }
        }

        [HttpPut]
        public ActionResult<Book> Put([FromBody] Book request)
        {
            Book book = session.Books.Where(x => x.id == request.id).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();

                book.author = request.author;
                book.title = request.title;
                book.genre = request.genre;
                book.pagecount = request.pagecount;

                session.Update(book);

                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, "Book Insert Error");
            }
            finally
            {
                session.CloseTransaction();
            }


            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult<Book> Delete(int id)
        {
            Book book = session.Books.Where(x => x.id == id).FirstOrDefault();
            if (book == null)
            {
                return NotFound();
            }

            try
            {
                session.BeginTransaction();
                session.Delete(book);
                session.Commit();
            }
            catch (Exception ex)
            {
                session.Rollback();
                Log.Error(ex, "Book Insert Error");
            }
            finally
            {
                session.CloseTransaction();
            }
            return Ok();
        }
    }
}
