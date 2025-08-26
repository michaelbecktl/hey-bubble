using Backend.Entity;
using Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/v1/user")]
public class UserController : ControllerBase
{
  private readonly AppDbContext _context;
  private readonly IUserService _userService;
  public UserController(AppDbContext context, IUserService userService)
  {
    _context = context;
    _userService = userService;
  }

  public class UserLogin
  {
    public string? Id { get; set; }
    public required string Username { get; set; }

    public required string Password { get; set; }
  }

  [Authorize]
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


  // User Registration
  [HttpPost]
  public async Task<IActionResult> Post(User newUser)
  {
    var user = await _userService.RegisterAsync(newUser);
    if (user is null)
      return Conflict("Username or email already exists");

    return CreatedAtAction(nameof(Get), newUser);
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
  {
    var token = await _userService.LoginAsync(userLogin);
    if (User is null)
      return Unauthorized("Invalid username and password");

    Console.WriteLine("Test Console Write:" + token);
    

    return Ok(token);
  }

  public IActionResult AuthenticatedOnlyEndpoint()
  {
    return Ok("You are authenticated!");
  }

  [Authorize]
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