namespace Liyanjie.HotChocolate.FluentValidation;

[AttributeUsage(AttributeTargets.Parameter)]
public class UseFluentValidationAttribute : ArgumentDescriptorAttribute
{
    protected override void OnConfigure(IDescriptorContext context, IArgumentDescriptor descriptor, ParameterInfo parameter)
    {
        descriptor.UseFluentValidation();
    }
}
