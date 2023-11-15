using JWT.DbContexts;
using JWT.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthService(AppDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async ValueTask<string> Login(RequestLogin request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == request.UserName);

            if (user is null)
            {
                throw new Exception("User not Found");
            }
            else if (user.PasswordHash != request.Password)
            {
                throw new Exception("Password is wrong!!");
            }
            return _tokenService.Generate(user.UserName);
        }
    }
}
