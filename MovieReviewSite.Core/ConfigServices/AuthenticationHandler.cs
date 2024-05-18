using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MovieReviewSite.Core.ConfigServices;

public class BasicAuthenticationHandler
{
}
//     : AuthenticationHandler<AuthenticationSchemeOptions>
// {
//     protected override Task<AuthenticateResult> HandleAuthenticateAsync()
//     {
//         // Basic authentication logic
//         // Extract username and password from the request headers
//
//         var claims = new List<Claim>
//         {
//             new Claim(ClaimTypes.Name, username),
//             new Claim(ClaimTypes.Role, "Admin") // Assigning the role "Admin" for demonstration purposes
//         };
//
//         var identity = new ClaimsIdentity(claims, Scheme.Name);
//         var principal = new ClaimsPrincipal(identity);
//         var ticket = new AuthenticationTicket(principal, Scheme.Name);
//
//         return Task.FromResult(AuthenticateResult.Success(ticket));
//     }
// }
