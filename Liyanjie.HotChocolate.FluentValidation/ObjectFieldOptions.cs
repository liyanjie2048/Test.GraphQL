namespace Liyanjie.HotChocolate.FluentValidation;

sealed class ObjectFieldOptions
{
    public IDictionary<string, IInputField> Arguments { get; } = new ConcurrentDictionary<string, IInputField>();
}
