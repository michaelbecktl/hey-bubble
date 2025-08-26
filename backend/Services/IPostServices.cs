using Backend.Entity;
using static UserController;

namespace Backend.Services
{
  public interface IPostService
  {
    Task<Post[]?> GetPublicPostsAsync();

    Task<Post[]?> GetFollowedPostsAsync(string username);

    Task<Post[]?> GetUserPostsAsync(string username);
  }
}