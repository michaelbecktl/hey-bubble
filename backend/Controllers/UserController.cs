using System.Security.Claims;
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

  public int RetrieveUserId()
  {
    var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
    return int.Parse(userIdString);
  }

  public class UserLogin
  {
    public required string Username { get; set; }

    public required string Password { get; set; }
  }

  [Authorize]
  [HttpGet]

  public async Task<IEnumerable<UserDTO>> GetUsers() =>
  await _context.Users
  .Select(user => new UserDTO { Id = user.Id, Username = user.Username, Email = user.Email })
  .ToListAsync();

  [Authorize]
  [HttpGet("{id}")]
  public async Task<ActionResult<UserDTO>> GetSpecificUser(int id)
  {
    var user = await _context.Users
    .Where(user => user.Id == id)
    .Select(user => new UserDTO { Id = user.Id, Username = user.Username, Email = user.Email })
    .FirstOrDefaultAsync();

    if (user == null) return NotFound();
    return user;
  }

  [Authorize]
  [HttpGet("profile/{id}")]
  public async Task<ActionResult<UserProfileDTO>> GetUserProfile(string id)
  {
    var userId = id == "current" ? RetrieveUserId() : int.Parse(id);

    var user = await _context.UserProfiles
    .Where(up => up.UserId == userId)
    .Select(up => new UserProfileDTO
    {
      UserId = up.UserId,
      DisplayName = up.DisplayName,
      Dob = up.Dob,
      ProfilePhoto = up.ProfilePhoto,
      Gender = up.Gender,
      Country = up.Country,
      NativeLanguage = up.NativeLanguage,
      LearningLanguage = up.LearningLanguage,
      Following = up.Following,
      Followers = up.Followers })
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

    return CreatedAtAction(nameof(Post), newUser);
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
  {
    var token = await _userService.LoginAsync(userLogin);
    if (token is null)
      return Unauthorized("Invalid username and password");

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