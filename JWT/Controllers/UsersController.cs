using JWT.DbContexts;
using JWT.Dtos;
using JWT.Entyties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JWT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;

        public UsersController(AppDbContext db)
        {
            _db = db;
        }

        [Authorize]
        [HttpGet]
        public async ValueTask<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> users = await _db.Users.ToListAsync();
            return users;
        }
        [HttpPost]
        public async ValueTask<bool> Create(UserDto user)
        {
            try
            {
                var us = new User();
                us.UserName = user.UserName;
                us.PasswordHash = user.PasswordHash;
                await _db.Users.AddAsync(us);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
