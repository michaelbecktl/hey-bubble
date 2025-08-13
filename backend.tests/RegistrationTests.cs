using Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using Backend.Models;
using Microsoft.Identity.Client;
using Xunit.Abstractions;
public class RegistrationTests : IClassFixture<TestingWebAppFactory<Program>>
{
  private readonly HttpClient _client;

  public RegistrationTests(TestingWebAppFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task GetListOfUsers()
  {
    var response = await _client.GetAsync("/api/v1/user");
    var users = await response.Content.ReadFromJsonAsync<User[]>();

    // Get request should retrieve a list of users //
    Assert.NotNull(users);
    Assert.Contains(users, user => user.Username == "alice");
  }

  [Fact]
  public async Task RegisteringNewUser()
  {
    var newUser = new User { Username = "jackson", Password = "testPassword", Email = "jackson@heybubble.co.nz" };
    var response = await _client.PostAsJsonAsync("/api/v1/user", newUser);

    // User should successfully register //
    Assert.True(response.IsSuccessStatusCode);
  }

    [Fact]
  public async Task RegisteringDuplicateUser()
  {
    var newUser = new User { Username = "bob", Password = "test", Email = "bob@heybubble.co.nz" };
    var response = await _client.PostAsJsonAsync("/api/v1/user", newUser);

    // Post request should fail as username and email already exists in database //
    Assert.False(response.IsSuccessStatusCode);
  }
}