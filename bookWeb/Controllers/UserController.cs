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
    public class UserController : ControllerBase
    {

        private readonly FavoritBookContext _context;
        public UserController(FavoritBookContext context)
        {
            _context = context;
        }
        [HttpGet("{_login}")]
        public int Get(string _login)
        {            
            int user_id = _context.User.Where(us => us.login == _login).Select(us => us.UserID).FirstOrDefault();

            if (user_id == 0)
            {
                User new_user = new User();
                new_user.login = _login;
                _context.Add(new_user);
                _context.SaveChanges();

                user_id = new_user.UserID;
            }

            return user_id;
        }

    }
}
