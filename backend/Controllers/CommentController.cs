using Backend.Services;
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
}