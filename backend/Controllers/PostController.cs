using System.Security.Claims;
using Backend.Entity;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/v1/post")]
public class PostController : ControllerBase
{
  private readonly AppDbContext _context;
  private readonly IPostService _postService;
  public PostController(AppDbContext context, IPostService postService)
  {
    _context = context;
    _postService = postService;
  }

  public int RetrieveUserId()
  {
    var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
    return int.Parse(userIdString);
  }

  [Authorize]
  [HttpGet]

  public async Task<ActionResult> GetPublicPosts()
  {
    var userId = RetrieveUserId();
    var posts = await _postService.GetPublicPostsAsync(userId);

    return Ok(posts);
  }

  [Authorize]
  [HttpGet("user")]

  public async Task<ActionResult> GetUserPosts()
  {
    var userId = RetrieveUserId();
    var posts = await _postService.GetUserPostsAsync(userId);

    return Ok(posts);
  }

  [Authorize]
  [HttpPost]

  public async Task<IActionResult> CreatePost(NewPostDTO request)
  {
    var userId = RetrieveUserId();
    var newPost = await _postService.CreateNewPostAsync(userId, request);

    return CreatedAtAction(nameof(CreatePost), newPost);
  }

}