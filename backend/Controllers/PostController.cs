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

  // [Authorize]
  // [HttpGet]

  // public async Task<ActionResult> Get() =>


}