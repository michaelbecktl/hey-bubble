using Backend.Entity;
using static UserController;

namespace Backend.Services
{
  public interface IPostService
  {
    Task<Post[]?> GetPublicPostsAsync();

    Task<Post[]?> GetFollowedPost(string username);

    Task<Post[]?> GetUserPost(string username);
  }
}