using Backend.Entity;

namespace Backend.Services
{
  public interface IPostService
  {
    Task<IEnumerable<PostDTO>?> GetPublicPostsAsync(int userId);

    // Task<Post[]?> GetFollowedPostsAsync(string username);

    Task<IEnumerable<PostDTO>?> GetUserPostsAsync(int userId);
    Task<Post> CreateNewPostAsync(int userId, NewPostDTO request);
    Task<Post?> UpdatePostAsync(int userId, int postId, UpdatePostDTO request);
    Task<bool> DeletePostAsync(int userId, int postId);
  }
}