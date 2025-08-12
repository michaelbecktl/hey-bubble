using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
  private readonly AppDbContext _context;
  public UserController(AppDbContext context) => _context = context;

  [HttpGet]
  public async Task<IEnumerable<User>> Get() =>
  await _context.Users.ToListAsync();

  [HttpPost]
  public async Task<IActionResult> Post(User newUser)
  {
    _context.Users.Add(newUser);
    await _context.SaveChangesAsync();
    return CreatedAtAction(nameof(Get), new { id = newUser.id }, newUser);
  }

}