using System.Security.Claims;

namespace Test.GraphQL.GraphQL;

public class UserContext(ClaimsPrincipal user) : Dictionary<string, object?>
{
    public ClaimsPrincipal User => user;
}
