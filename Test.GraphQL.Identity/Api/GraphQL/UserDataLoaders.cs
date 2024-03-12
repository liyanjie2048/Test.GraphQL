namespace Test.GraphQL.Identity.Api.GraphQL;

public class UserDataLoaders
{
    [DataLoader(ServiceScope = DataLoaderServiceScope.DataLoaderScope)]
    internal static async Task<IReadOnlyDictionary<Guid, User>> GetUserByIdAsync(
        IReadOnlyList<Guid> ids,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        Console.WriteLine($"UserByIdDataLoader.GetUserByIdAsync:ids={ids}");
        return UserQueries.Users.Where(_ => ids.Contains(_.Id)).ToDictionary(_ => _.Id);
    }
}
