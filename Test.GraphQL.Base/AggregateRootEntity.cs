namespace Test.GraphQL.Base;

public abstract class AggregateRootEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
