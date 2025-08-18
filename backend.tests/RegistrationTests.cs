using Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using Backend.Entity;
using Microsoft.Identity.Client;
using Xunit.Abstractions;
using Microsoft.AspNetCore.Identity;
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
  public async Task GetListOfUsers()
  {
    var response = await _client.GetAsync("/api/v1/user");
    var users = await response.Content.ReadFromJsonAsync<UserDTO[]>();

    // Get request should retrieve a list of users //
    Assert.NotNull(users);
    Assert.Contains(users, user => user.Username == "alice");
  }

  [Fact]
  public async Task RegisteringNewUser()
  {
    var newUser = new User { Username = "jackson", Password = "jacksontest", Email = "jackson@heybubble.co.nz" };
    var response = await _client.PostAsJsonAsync("/api/v1/user", newUser);

    // User should successfully register //
    Assert.True(response.IsSuccessStatusCode);
  }

  [Fact]
  public async Task RegisteringDuplicateUser()
  {
    var newUser = new User { Username = "bob", Password = "bobtest", Email = "bob@heybubble.co.nz" };
    var response = await _client.PostAsJsonAsync("/api/v1/user", newUser);

    // Post request should fail as username and email already exists in database //
    Assert.False(response.IsSuccessStatusCode);
  }

  [Fact]
  public async Task UserLoginSuccess()
  {
    var validLogin = new UserLogin { Username = "bob", Password = "bobtest" };
    var validResponse = await _client.PostAsJsonAsync("/api/v1/user/login", validLogin);

    var invalidLogin = new UserLogin { Username = "bob", Password = "failtest" };
    var invalidResponse = await _client.PostAsJsonAsync("/api/v1/user/login", invalidLogin);

    // User should be able to login with correct credentials //
    Assert.True(validResponse.IsSuccessStatusCode);
    Assert.False(invalidResponse.IsSuccessStatusCode);


  }
}