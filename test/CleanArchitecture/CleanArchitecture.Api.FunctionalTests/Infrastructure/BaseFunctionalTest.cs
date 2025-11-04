using System.Configuration;
using System.Net.Http.Json;
using CleanArchitecture.Api.FunctionalTests.Users;
using CleanArchitecture.Application.Users.LoginUser;
using Xunit;

namespace CleanArchitecture.Api.FunctionalTests.Infrastructure;

public abstract class BaseFunctionalTest :
IClassFixture<FunctionalTestsWebAppFactory>
{

    protected readonly HttpClient HttpClient;

    protected BaseFunctionalTest(FunctionalTestsWebAppFactory factory)
    {
        HttpClient = factory.CreateClient();
    }

    protected async Task<string> GetToken()
    {
        HttpResponseMessage response = await HttpClient.PostAsJsonAsync(
            "api/v1/users/login",
            new LoginUserRequest(
                UserData.RegisterUserRequestTest.Email,
                UserData.RegisterUserRequestTest.Password
            )
        );

        return await response.Content.ReadAsStringAsync();
    }



}