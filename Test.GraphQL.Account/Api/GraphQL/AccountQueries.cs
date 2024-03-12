using Bogus;

using Test.GraphQL.Base;

using Account_ = Test.GraphQL.Account.Domain.Models.AccountAggregate.Account;

namespace Test.GraphQL.Account.Api.GraphQL
{
    [QueryType]
    public class AccountQueries
    {
        public static readonly IEnumerable<Account_> Accounts = new Faker<Account_>("zh_CN")
            .RuleFor(_ => _.Balance, f => f.PickRandom((int[])[10, 20, 30, 40]))
            .GenerateLazy(6)
            .Select((_, i) =>
            {
                _.Id = Static.Guids[i];
                _.User_Id = Static.Guids[i];
                return _;
            });

        [UseOffsetPaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Account_> GetAccounts()
        {
            return Accounts.AsQueryable();
        }

        public async Task<Account_> GetAccount(Guid id,
            IAccountByIdDataLoader dataLoader)
        {
            return await dataLoader.LoadAsync(id);
        }

        public async Task<Account_> GetAccountByUserId(Guid userId,
            IAccountByUserIdDataLoader dataLoader)
        {
            return await dataLoader.LoadAsync(userId);
        }
    }
}
