namespace Liyanjie.HotChocolate.FluentValidation;

static class FluentValidationMiddleware
{
    public static FieldMiddleware Middleware = new((next) =>
    {
        return async middlewareContext =>
        {
            if (middlewareContext.Selection.SyntaxNode.Arguments.Count > 0)
            {
                var objectFieldOptions = middlewareContext.Selection.Field.ContextData.GetObjectFieldOptions();
                if (objectFieldOptions is null)
                    return;

                foreach (var argument in middlewareContext.Selection.SyntaxNode.Arguments)
                {
                    if (objectFieldOptions.Arguments.TryGetValue(argument.Name.Value, out var inputField))
                    {
                        var validatorType = typeof(IValidator<>).MakeGenericType(inputField.RuntimeType);
                        if (middlewareContext.RequestServices.GetService(validatorType) is IValidator validator)
                        {
                            var inputValue = middlewareContext.ArgumentValue<object>(inputField.Name);
                            var validationResult = await validator.ValidateAsync(new ValidationContext<object>(inputValue));
                            if (!validationResult.IsValid)
                            {
                                var errors = validationResult.Errors
                                    .GroupBy(_ => _.PropertyName)
                                    .ToDictionary(_ => _.Key, _ => _.Select(__ => new
                                    {
                                        __.ErrorMessage,
                                        __.ErrorCode,
                                        __.Severity,
                                        __.CustomState,
                                        __.AttemptedValue,
                                        __.FormattedMessagePlaceholderValues,
                                    }));
                                middlewareContext.ReportError(ErrorBuilder.New()
                                    .SetPath(middlewareContext.Path)
                                    .SetMessage("Validation failed.")
                                    .SetExtension(nameof(errors), JsonSerializer.Serialize(errors))
                                    .Build());
                            }
                        }
                    }
                }
            }

            if (!middlewareContext.HasErrors)
            {
                await next(middlewareContext);
            }
        };
    });
}
