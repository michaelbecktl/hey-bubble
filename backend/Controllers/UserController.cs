using Backend.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/v1/user/register")]
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
    // Checks if database already has an existing user with the same details as new user's registration //
    var existingUser = await _context.Users
      .Where(users => users.Username == newUser.Username || users.Email == newUser.Email)
      .Select(user => new { user.Username, user.Email })
      .FirstOrDefaultAsync();

    if (existingUser != null)
    {
      if (existingUser.Username == newUser.Username) return Conflict(new { message = "Username already exists" });
      if (existingUser.Email == newUser.Email) return Conflict(new { message = "Email already exists" });
    }

    // Hashing new user's password before storing into database //
    newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);
    Console.WriteLine(newUser.Password);

    return Ok();
 
    // _context.Users.Add(newUser);
    // await _context.SaveChangesAsync();
    // return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
  }

}