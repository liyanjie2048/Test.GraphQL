namespace Test.GraphQL.Combine.Api.GraphQL;

[ExtendObjectType<User>]
public class UserExtensions
{
    public async Task<Account_> GetAccount([Parent] User user,
        IAccountByUserIdDataLoader dataLoader)
    {
        return await dataLoader.LoadAsync(user.Id);
    }
}
