using Backend.Entity;
using static UserController;

namespace Backend.Services
{
  public interface IPostService
  {
    Task<PostDTO[]?> GetPublicPostsAsync(int userId);

    // Task<Post[]?> GetFollowedPostsAsync(string username);

    Task<PostDTO[]?> GetUserPostsAsync(int userId);
    Task<Post> CreateNewPostAsync(int userId, NewPostDTO request);
  }
}