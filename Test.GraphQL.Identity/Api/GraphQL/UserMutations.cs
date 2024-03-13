namespace Test.GraphQL.Identity.Api.GraphQL;

[MutationType]
public class UserMutations
{
    public async Task<bool> LikeUserById(Guid id,
        IUserByIdDataLoader dataLoader)
    {
        var user = await dataLoader.LoadAsync(id);
        return true;
    }

    public async Task<UserModifyPayload> ModifyUserById(Guid id,
        UserModifyRequest input,
        IUserByIdDataLoader dataLoader)
    {
        var user = await dataLoader.LoadAsync(id);
        user.Age = input.Age;
        return new(true, user);
    }
}