using System.Security.Claims;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/like")]

public class LikeController : ControllerBase
{
  private readonly AppDbContext _context;
  private readonly ILikeService _likeService;

  public LikeController(AppDbContext context, ILikeService likeService)
  {
    _context = context;
    _likeService = likeService;
  }

  public int RetrieveUserId()
  {
    var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
    return int.Parse(userIdString);
  }

  [Authorize]
  [HttpPost("post/{postId}")]
  public async Task<IActionResult> AddLikeToPost(string postId)
  {
    var userId = RetrieveUserId();
    var like = await _likeService.AddLikeToPost(userId, int.Parse(postId));

    return Ok(like);
  }

  [Authorize]
  [HttpDelete("post/{postId}")]
  public async Task<IActionResult> DeleteLikeFromPost(string postId)
  {
    var userId = RetrieveUserId();
    var deletedLike = await _likeService.DeleteLikeFromPost(userId, int.Parse(postId));

    if (deletedLike) return Ok(new { message = "Like removed from post successfully" });
    else return NotFound(new { message = "Like could not be added to post" });
  }

  [Authorize]
  [HttpPost("comment/{commentId}")]
  public async Task<IActionResult> AddLikeToComment(string commentId)
  {
    var userId = RetrieveUserId();
    var like = await _likeService.AddLikeToComment(userId, int.Parse(commentId));

    return Ok(like);
  }

  [Authorize]
  [HttpDelete("comment/{commentId}")]
  public async Task<IActionResult> DeleteLikeFromComment(string commentId)
  {
    var userId = RetrieveUserId();
    var deletedLike = await _likeService.DeleteLikeFromComment(userId, int.Parse(commentId));

    if (deletedLike) return Ok(new { message = "Like removed from comment successfully" });
    else return NotFound(new { message = "Like could not be added to comment" });
  }
}