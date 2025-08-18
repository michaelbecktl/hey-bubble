using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Entity;
using BCrypt.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

[ApiController]
[Route("api/v1/user")]
public class UserController : ControllerBase
{
  private readonly AppDbContext _context;
  private readonly IConfiguration _configuration;
  public UserController(AppDbContext context, IConfiguration configuration)
  {
    _context = context;
    _configuration = configuration;
  }

  public class UserLogin
  {
    public required string Username { get; set; }

    public required string Password { get; set; }
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


  // User Registration
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
    .FirstOrDefaultAsync(users => users.Username == userLogin.Username);

    if (existingUser == null) return Unauthorized(new { message = "Invalid username and password" });

    bool isMatchingPassword = BCrypt.Net.BCrypt.Verify(userLogin.Password, existingUser.Password);
    if (!isMatchingPassword) return Unauthorized(new { message = "Invalid username and password" });

    string token = CreateToken(userLogin);

    return Ok(token);

  }

  private string CreateToken(UserLogin user)
  {
    var claims = new List<Claim>
    {
      new Claim(ClaimTypes.Name, user.Username)
    };

    var key = new SymmetricSecurityKey(
      Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));

    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

    var tokenDescriptor = new JwtSecurityToken(
      issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
      audience: _configuration.GetValue<string>("AppSettings:Audience"),
      claims: claims,
      expires: DateTime.UtcNow.AddMinutes(15),
      signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
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