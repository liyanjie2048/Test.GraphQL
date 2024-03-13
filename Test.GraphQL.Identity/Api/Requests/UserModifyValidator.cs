namespace Test.GraphQL.Identity.Api.Requests;

public class UserModifyValidator : AbstractValidator<UserModifyRequest>
{
    public UserModifyValidator()
    {
        RuleFor(_ => _.Age)
            .Must((age) => age > 100).WithMessage("年龄必须大于100");

        RuleFor(_ => _.UserName)
            .MinimumLength(6).WithMessage("用户名长度不能小于6");
    }
}
