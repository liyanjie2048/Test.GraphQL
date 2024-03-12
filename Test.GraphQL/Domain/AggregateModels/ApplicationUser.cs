namespace Test.GraphQL.Domain.AggregateModels;

public class ApplicationUser
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Contact { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; } = DateTime.Now;
}
