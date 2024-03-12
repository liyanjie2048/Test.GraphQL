namespace Liyanjie.HotChocolate.FluentValidation;

static class Extensions
{
    public static string Key_UseFluentValidation = "UseFluentValidation";
    public static string Key_ObjectFieldOptions = "ObjectFieldOptions";

    public static void CreateObjectFieldOptions(this ExtensionData extensionData)
    {
        extensionData[Key_ObjectFieldOptions] = new ObjectFieldOptions();
    }
    public static ObjectFieldOptions? GetObjectFieldOptions(this IReadOnlyDictionary<string, object?> contextData)
    {
        return contextData.TryGetValue(Key_ObjectFieldOptions, out var value) && value is ObjectFieldOptions options
            ? options
            : default;
    }
    public static bool IsUseFluentValidation(this IReadOnlyDictionary<string, object?> contextData)
    {
        return contextData.TryGetValue(Key_UseFluentValidation, out _);
    }
}
