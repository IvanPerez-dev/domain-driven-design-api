using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CleanArchitecture.Domain.Users;
using Newtonsoft.Json;

namespace CleanArchitecture.Infrastructure.Authentication;

internal static class ClaimsPrincipalExtensions
{

    public static string GetUserEmail(this ClaimsPrincipal? claimsPrincipal)
    {
        return claimsPrincipal?.FindFirstValue(ClaimTypes.Email)
        ?? throw new ApplicationException("El email no esta disponible");
    }

    public static Guid GetUserId(this ClaimsPrincipal? claimsPrincipal)
    {

        var userId = claimsPrincipal?.FindFirstValue(ClaimTypes.NameIdentifier);
        
         return Guid.TryParse(userId, out var parsedUserId) ?
            parsedUserId :
            throw new ApplicationException("User id no esta disponible");
    }


}