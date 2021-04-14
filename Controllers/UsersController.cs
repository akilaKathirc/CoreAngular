using DatingApp.Data;
using DatingApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]



        public async Task<ActionResult<IEnumerable<UserEntity>>> GetUsers()
        {
            var user  = await   _context.Users.ToListAsync();

            return user;
        }

        [HttpGet("{id}")]
        public ActionResult<UserEntity> GetUser(int id)
        {
            return _context.Users.Where(user =>
                               user.Id == id
                            ).FirstOrDefault();
        }

    }
}
