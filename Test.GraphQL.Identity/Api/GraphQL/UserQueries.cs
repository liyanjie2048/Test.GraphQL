namespace Test.GraphQL.Identity.Api.GraphQL;

[QueryType]
public class UserQueries
{
    public static readonly IEnumerable<User> Users = new Faker<User>("zh_CN")
        .RuleFor(_ => _.UserName, _ => _.Phone.PhoneNumber("15#########"))
        .RuleFor(_ => _.Password, (f, u) => u.Id.ToString("N")[..10])
        .RuleFor(_ => _.Sex, f => f.PickRandomParam<bool?>([true, false, null]))
        .RuleFor(_ => _.Age, f => f.PickRandom((int[])[10, 20, 30, 40]))
        .GenerateLazy(6)
        .Select((_, i) =>
        {
            _.Id = Static.Guids[i];
            return _;
        });

    [UseOffsetPaging(IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    public IQueryable<User> GetUsers()
    {
        return Users.AsQueryable();
    }

    public async Task<User?> GetUser(Guid id,
        IUserByIdDataLoader dataLoader)
    {
        Console.WriteLine($"GetUserById:id={id}");
        return await dataLoader.LoadAsync(id);
    }
}
