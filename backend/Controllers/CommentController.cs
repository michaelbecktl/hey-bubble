using System.Security.Claims;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/comment")]

public class CommentController : ControllerBase
{
  private readonly AppDbContext _context;
  private readonly ICommentService _commentService;

  public CommentController(AppDbContext context, ICommentService commentService)
  {
    _context = context;
    _commentService = commentService;
  }

  public int RetrieveUserId()
  {
    var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
    return int.Parse(userIdString);
  }

  [Authorize]
  [HttpGet("{postId}")]

  public async Task<ActionResult> GetCommentsByPostId(string postId)
  {

    var userId = RetrieveUserId();
    var comments = await _commentService.GetCommentByPostIdAsync(userId, int.Parse(postId));

    return Ok(comments);
  }

  [Authorize]
  [HttpPost]
  public async Task<IActionResult> CreateNewComment(NewCommentDTO request)
  {
    var userId = RetrieveUserId();
    var newComment = await _commentService.CreateNewCommentAsync(userId, request);

    return CreatedAtAction(nameof(CreateNewComment), newComment);
  }

  [Authorize]
  [HttpPatch("{commentId}")]
  public async Task<IActionResult> UpdateComment(string commentId, UpdateCommentDTO request)
  {
    var userId = RetrieveUserId();
    var updatedComment = await _commentService.UpdateCommentAsync(userId, int.Parse(commentId), request);

    if (updatedComment != null) return Ok(new { message = "Comment updated successfully" });
    else return NotFound(new { message = "Comment not found" });
  }

  [Authorize]
  [HttpDelete("{commentId}")]
  public async Task<IActionResult> DeleteComment(string commentId)
  {
    var userId = RetrieveUserId();
    var deletedComment = await _commentService.DeleteCommentAsync(userId, int.Parse(commentId));

    if (deletedComment) return Ok(new { message = "Comment deleted successfully" });
    else return NotFound(new { message = "Comment not found" });
  }
}