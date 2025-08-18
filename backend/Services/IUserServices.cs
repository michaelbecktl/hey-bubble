using Backend.Entity;
using static UserController;

namespace Backend.Services
{
  public interface IUserService
  {
    Task<User?> RegisterAsync(User request);
    Task<string?> LoginAsync(UserLogin request);
  }
}