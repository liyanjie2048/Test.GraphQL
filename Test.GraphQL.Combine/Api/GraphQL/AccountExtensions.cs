namespace Test.GraphQL.Combine.Api.GraphQL;

[ExtendObjectType<Account_>]
public class AccountExtensions
{
    public async Task<User> GetUser([Parent] Account_ account,
        IUserByIdDataLoader dataLoader)
    {
        return await dataLoader.LoadAsync(account.User_Id);
    }
}
