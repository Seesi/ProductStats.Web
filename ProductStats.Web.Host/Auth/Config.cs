using IdentityServer4.Models;

namespace ProductStats.Web.Host.Auth;
public static class Config
{
    public const string UserRole = "User";
    public const string ApiName = "productstatsapi";
    public const string ApiReadScope = "productstatsapi.read";
    public const string ApiWriteScope = "productstatsapi.write";

    public static IEnumerable<ApiScope> ApiScopes =>
      new[]
      {
        new ApiScope(ApiReadScope),
        new ApiScope(ApiWriteScope),
      };

    public static IEnumerable<Client> Clients =>
      new[]
      {
        new Client
        {
          ClientId = "postman.client",
          ClientName = "Postman Collection",

          AllowedGrantTypes = GrantTypes.ClientCredentials,
          ClientSecrets = {new Secret("Secure@123".Sha256())},

          AllowedScopes = {ApiReadScope}
        },
      };
}
