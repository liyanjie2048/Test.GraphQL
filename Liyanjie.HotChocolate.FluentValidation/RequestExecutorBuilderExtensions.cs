namespace Liyanjie.HotChocolate.FluentValidation;

public static class RequestExecutorBuilderExtensions
{
    public static IRequestExecutorBuilder AddFluentValidation(this IRequestExecutorBuilder builder)
    {
        builder.TryAddTypeInterceptor<FluentValidationInterceptor>();

        return builder;
    }
}
