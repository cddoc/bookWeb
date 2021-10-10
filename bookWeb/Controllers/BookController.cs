using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookWeb.Data;

namespace bookWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private readonly FavoritBookContext _context;
        public BookController(FavoritBookContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<ListBook> Get()
        {
            List<ListBook> lBook = new List<ListBook>();
            var query = _context.Book.ToList();

            foreach(var item in query)
            {
                lBook.Add(new ListBook { bookID = item.BookID, author = item.author, title = item.title });
            }

            return lBook;
        }
    }
}
