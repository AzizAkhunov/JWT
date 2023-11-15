using JWT.Dtos;
using JWT.Entyties;

namespace JWT.Services
{
    public interface IUserService
    {
        ValueTask<bool> CreateUserAsync(UserDto user);
        ValueTask<IEnumerable<User>> GetAllUsers();
    }
}
