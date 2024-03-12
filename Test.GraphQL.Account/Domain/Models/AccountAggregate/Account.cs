using Test.GraphQL.Base;

namespace Test.GraphQL.Account.Domain.Models.AccountAggregate;

public class Account : AggregateRootEntity
{
    public decimal Balance { get; set; }

    public required Guid User_Id { get; set; }
}
