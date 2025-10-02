using System.Net.Http.Headers;
using System.Net.Http.Json;

public class ContentTests : IClassFixture<TestingWebAppFactory<Program>>
{
  private readonly HttpClient _client;

  public ContentTests(TestingWebAppFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }
  
    public class UserLogin
  {
    public required string Username { get; set; }

    public required string Password { get; set; }
  }

  public async Task<string> GetToken(string username, string password)
  {
    var user = new UserLogin { Username = username, Password = password };
    var response = await _client.PostAsJsonAsync("/api/v1/user/login", user);
    return await response.Content.ReadAsStringAsync();
  }



  // [Fact]
  // public async Task ViewAllPosts()
  // {
  //   var token = await GetToken("hanauser", "hanatest");
  //   _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
  //   var response = await _client.GetAsync("/api/v1/post");
  //   Console.WriteLine($"Bearer {token}");
  //   Console.WriteLine("Response Result: " + response);

  //   Assert.True(response.IsSuccessStatusCode);
  // }

  // public Task AddNewPost()
  // {
  //   // Arrange //

  //   // Act //

  //   // Assert //
  // }

  // public Task EditPost()
  // {
  //   // Arrange //

  //   // Act //

  //   // Assert //
  // }

  // public Task DeletePost()
  // {
  //   // Arrange //

  //   // Act //

  //   // Assert //
  // }
}
