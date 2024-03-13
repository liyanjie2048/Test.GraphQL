namespace Test.GraphQL.Account.Api.GraphQL;

[SubscriptionType]
public class AccountSubscriptions
{
    [Subscribe]
    public Account_? AccountChanged([EventMessage] Account_? account) => account;
}
