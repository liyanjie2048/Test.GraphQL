using Account_ = Test.GraphQL.Account.Domain.Models.AccountAggregate.Account;

namespace Test.GraphQL.Account.Api.GraphQL;

public class AccountDataLoaders
{
    [DataLoader(ServiceScope = DataLoaderServiceScope.DataLoaderScope)]
    internal static async Task<IReadOnlyDictionary<Guid, Account_>> GetAccountByIdAsync(
        IReadOnlyList<Guid> ids,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        Console.WriteLine($"GetAccountByIdAsync:ids={ids}");
        return AccountQueries.Accounts.Where(_ => ids.Contains(_.Id)).ToDictionary(_ => _.Id);
    }

    [DataLoader(ServiceScope = DataLoaderServiceScope.DataLoaderScope)]
    internal static async Task<IReadOnlyDictionary<Guid, Account_>> GetAccountByUserIdAsync(
       IReadOnlyList<Guid> userIds,
       CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        Console.WriteLine($"GetAccountByUserIdAsync:userIds={userIds}");
        return AccountQueries.Accounts.Where(_ => userIds.Contains(_.User_Id)).ToDictionary(_ => _.User_Id);
    }
}
