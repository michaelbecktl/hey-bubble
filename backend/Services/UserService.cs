using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Entity;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

using Microsoft.IdentityModel.Tokens;
using static UserController;

public class UserService(AppDbContext context, IConfiguration configuration) : IUserService
{

  public async Task<string?> LoginAsync(UserController.UserLogin userLogin)
  {
    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userLogin.Password);

    var existingUser = await context.Users
    .FirstOrDefaultAsync(users => users.Username == userLogin.Username);

    if (existingUser == null) return null;

    bool isMatchingPassword = BCrypt.Net.BCrypt.Verify(userLogin.Password, existingUser.Password);
    if (!isMatchingPassword) return null;

    return CreateToken(existingUser.Id.ToString());

  }

  public async Task<User?> RegisterAsync(User newUser)
  {
    // Checks if database already has an existing user with the same details as new user's registration //
    var existingUser = await context.Users
      .Where(users => users.Username == newUser.Username || users.Email == newUser.Email)
      .Select(user => new { user.Username, user.Email })
      .FirstOrDefaultAsync();

    if (existingUser != null)
    {
      if (existingUser.Username == newUser.Username || existingUser.Email == newUser.Email) return null;
    }

    // Hashing new user's password before storing into database //
    newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

    context.Users.Add(newUser);
    await context.SaveChangesAsync();
    return newUser;
  }

  private string CreateToken(string userId)
  {
    var claims = new List<Claim>
    {
      new Claim(ClaimTypes.NameIdentifier, userId)
    };

    var key = new SymmetricSecurityKey(
      Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

    var tokenDescriptor = new JwtSecurityToken(
      issuer: configuration.GetValue<string>("AppSettings:Issuer"),
      audience: configuration.GetValue<string>("AppSettings:Audience"),
      claims: claims,
      expires: DateTime.UtcNow.AddMinutes(15),
      signingCredentials: creds
    );

    return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
  }
}

