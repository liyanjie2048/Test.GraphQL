namespace Liyanjie.HotChocolate.FluentValidation;

public class FluentValidationInterceptor : TypeInterceptor
{
    public override void OnBeforeCompleteMutationField(ITypeCompletionContext completionContext, ObjectFieldDefinition mutationField)
    {
        if (mutationField.Arguments.Any(_ => _.ContextData.IsUseFluentValidation()))
        {
            mutationField.ContextData.CreateObjectFieldOptions();
            mutationField.MiddlewareDefinitions.Insert(0, new(FluentValidationMiddleware.Middleware));
        }
    }

    public override void OnAfterCompleteType(ITypeCompletionContext completionContext, DefinitionBase definition)
    {
        if (completionContext.Type is IObjectType objectType)
        {
            foreach (var objectField in objectType.Fields)
            {
                var objectFieldOptions = objectField.ContextData.GetObjectFieldOptions();
                if (objectFieldOptions is null)
                    continue;

                foreach (var argument in objectField.Arguments.Where(_ => _.ContextData.IsUseFluentValidation()))
                {
                    objectFieldOptions.Arguments.Add(argument.Name, argument);
                }
            }
        }
    }
}
