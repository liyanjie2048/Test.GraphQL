namespace Test.GraphQL.Identity.Api.GraphQL;

[MutationType]
public class UserMutations
{
    public async Task<UserModifyPayload> LikeUserById(Guid id,
        IUserByIdDataLoader dataLoader)
    {
        var user = await dataLoader.LoadAsync(id);
        return new(user);
    }

    public async Task<UserModifyPayload> ModifyUserById(Guid id,
        UserModifyInput input,
        IUserByIdDataLoader dataLoader)
    {
        var user = await dataLoader.LoadAsync(id);
        user.Age = input.Age;
        return new(user);
    }
}

public record UserModifyPayload(User User);
public record UserModifyInput(int Age);