using FluentValidation;

namespace Test.GraphQL.Identity.Api.Requests
{
    public class UserModifyValidator : AbstractValidator<UserModifyRequest>
    {
        public UserModifyValidator()
        {
            RuleFor(_ => _.Age)
                .Must((age) => age > 100).WithMessage("年龄必须大于100");
            RuleFor(_ => _.UserName)
                .NotEmpty().WithMessage("请输入用户名");
        }
    }
}
