using System.Net.Http.Json;
using Backend.Entity;
public class RegistrationTests : IClassFixture<TestingWebAppFactory<Program>>
{
  private readonly HttpClient _client;
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

  public RegistrationTests(TestingWebAppFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task RegisteringNewUser()
  {
    var newUser = new User { Username = "jacksonuser", Password = "jacksontest", Email = "jackson@heybubble.co.nz" };
    var response = await _client.PostAsJsonAsync("/api/v1/user", newUser);

    // User should successfully register //
    Assert.True(response.IsSuccessStatusCode);
  }

  [Fact]
  public async Task RegisteringDuplicateUser()
  {
    var newUser = new User { Username = "bobuser", Password = "bobtest", Email = "bob@heybubble.co.nz" };
    var response = await _client.PostAsJsonAsync("/api/v1/user", newUser);

    // Post request should fail as username and email already exists in database //
    Assert.False(response.IsSuccessStatusCode);
  }

  [Fact]
  public async Task UserLoginSuccess()
  {
    var validLogin = new UserLogin { Username = "bobuser", Password = "bobtest" };
    var validResponse = await _client.PostAsJsonAsync("/api/v1/user/login", validLogin);

    var invalidLogin = new UserLogin { Username = "bobuser", Password = "failtest" };
    var invalidResponse = await _client.PostAsJsonAsync("/api/v1/user/login", invalidLogin);

    // User should be able to login with correct credentials //
    Assert.True(validResponse.IsSuccessStatusCode);
    Assert.False(invalidResponse.IsSuccessStatusCode);
  }
}