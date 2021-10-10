using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookWeb.Data;
using bookWeb.Model;

namespace bookWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FavoritBookController : ControllerBase
    {
        private readonly FavoritBookContext _context;
        public FavoritBookController(FavoritBookContext context)
        {
            _context = context;
        }
        [HttpGet("{_user_id}")]
        public List<ListBook> Get(int _user_id)
        {    
            var query = (
                        from book in _context.Book
                        join fbook in _context.FavoritBook on book.BookID equals fbook.BooksID 
                        where fbook.UsersID == _user_id
                        select new { title=book.title
                                      , author = book.author
                                      , BookID = book.BookID
                                    }
                        );

            List<ListBook> lBook = new List<ListBook>();

            foreach (var item in query)
            {
                lBook.Add(new ListBook { bookID = item.BookID, author = item.author, title = item.title});
            }

            return lBook;
        }
        [HttpGet("{_user_id}/{_book_id}")]
        public List<ListBook> Get(int _user_id, int _book_id)
        {
            FavoritBook favoritBook = new FavoritBook();

            favoritBook.BooksID = _book_id;
            favoritBook.UsersID = _user_id;

            _context.Add(favoritBook);
            _context.SaveChanges();

            var query = (
                        from book in _context.Book
                        join fbook in _context.FavoritBook on book.BookID equals fbook.BooksID
                        where fbook.UsersID == _user_id
                        select new
                        {
                            title = book.title
                                      ,
                            author = book.author
                                      ,
                            BookID = book.BookID
                        }
                        );

            List<ListBook> lBook = new List<ListBook>();

            foreach (var item in query)
            {
                lBook.Add(new ListBook { bookID = item.BookID, author = item.author, title = item.title });
            }

            return lBook;
        }

    }
}
