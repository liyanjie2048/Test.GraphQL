namespace Test.GraphQL.Identity.Api.Requests;

public class UserModifyRequest : IRequest<UserModifyPayload>
{
    public int Age { get; set; }
    public required string UserName { get; set; }
}
