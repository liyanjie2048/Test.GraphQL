using HotChocolate.Subscriptions;

using Account_ = Test.GraphQL.Account.Domain.Models.AccountAggregate.Account;

namespace Test.GraphQL.Account.Api.GraphQL;

[MutationType]
public class AccountMutations
{
    public async Task<AccountModifyPayload> ModifyAccountById(Guid id,
        AccountModifyInput input,
        IAccountByIdDataLoader dataLoader,
        ITopicEventSender eventSender)
    {
        var account = await dataLoader.LoadAsync(id);
        account.Balance = input.Balance;
        await eventSender.SendAsync(nameof(AccountSubscriptions.AccountChanged), account);
        return new(account);
    }
}

public record AccountModifyPayload(Account_ Acount);
public record AccountModifyInput(decimal Balance);