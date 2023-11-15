using JWT.Models;

namespace JWT.Services
{
    public interface IAuthService
    {
        ValueTask<string> Login(RequestLogin request);
    }
}
