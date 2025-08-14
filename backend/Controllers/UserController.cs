using Backend.Models;
using BCrypt.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/v1/user")]
public class UserController : ControllerBase
{
  private readonly AppDbContext _context;
  public UserController(AppDbContext context) => _context = context;

  public class UserLogin
  {
    public required string Username { get; set; }

    public required string Password { get; set; }
  }
  
  public class UserDTO
  {
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
  }

  [HttpGet]

  public async Task<IEnumerable<UserDTO>> Get() =>
  await _context.Users
  .Select(user => new UserDTO { Id = user.Id, Username = user.Username, Email = user.Email })
  .ToListAsync();

  [HttpGet("{id}")]
  public async Task<ActionResult<UserDTO>> Get(int id)
  {
    var user = await _context.Users
    .Where(user => user.Id == id)
    .Select(user => new UserDTO { Id = user.Id, Username = user.Username, Email = user.Email })
    .FirstOrDefaultAsync();
    
    if (user == null) return NotFound();
    return user;
  }

  [HttpPost]
  public async Task<IActionResult> Post(User newUser)
  {
    // Checks if database already has an existing user with the same details as new user's registration //
    Console.WriteLine(newUser);
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

    _context.Users.Add(newUser);
    await _context.SaveChangesAsync();
    return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
  {
    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userLogin.Password);

    var existingUser = await _context.Users
    .FirstOrDefaultAsync(users => users.Username == userLogin.Username || users.Email == userLogin.Username);

    if (existingUser == null) return Unauthorized(new { message = "Username/Email Address not found" });

    bool isMatchingPassword = BCrypt.Net.BCrypt.Verify(userLogin.Password, existingUser.Password);
    if (!isMatchingPassword) return Unauthorized(new { message = "Password is incorrect" });

    return Ok(new { message = "Login successful", id = existingUser.Id });
  }


  [HttpDelete("{user}")]
  public async Task<IActionResult> Delete(string user)
  {
    {
      if (string.IsNullOrWhiteSpace(user))
      {
        return BadRequest(new { message = "Username must be provided." });
      }

      var deleted = await _context.Users
        .Where(users => users.Username == user)
        .ExecuteDeleteAsync();

      if (deleted > 0)
      {
        return Ok(new { message = "User deleted successfully" });
      }
      else
      {
        return NotFound(new { message = "User not found" });
      }
    }

  }
}