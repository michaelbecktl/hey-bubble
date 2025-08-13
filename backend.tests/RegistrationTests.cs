using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace backend.tests;

public class RegistrationTests : WebApplicationFactory<Program>
{
  [Fact]
  public async Task Test1()
  {
        var client = CreateClient();
        var response = await client.GetAsync("/api/v1/user/register");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

  }
}
