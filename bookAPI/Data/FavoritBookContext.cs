using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookWeb.Model;

namespace bookAPI.Data
{
    public class FavoritBookContext : DbContext
    {
        public FavoritBookContext(DbContextOptions<FavoritBookContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<FavoritBook> FavoritBook { get; set; }

    }
}
