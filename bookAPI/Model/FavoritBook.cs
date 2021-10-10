using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookWeb.Model
{
    public class FavoritBook
    {
        public int FavoritBookID { get; set; }
        public int BooksID { get; set; }
        public int UsersID { get; set; }
    }
}
