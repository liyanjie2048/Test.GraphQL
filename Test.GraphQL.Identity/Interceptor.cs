using HotChocolate.Configuration;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;

namespace Test.GraphQL.Identity;

public class Interceptor : TypeInterceptor
{
    //0
    public override void OnBeforeDiscoverTypes()
    {
        Console.WriteLine("00\tOnBeforeDiscoverTypes()");
    }



    //1
    public override void OnBeforeInitialize(ITypeDiscoveryContext discoveryContext)
    {
        Console.WriteLine("01\tOnBeforeInitialize(discoveryContext)");
    }
    //2
    public override void OnBeforeRegisterDependencies(ITypeDiscoveryContext discoveryContext, DefinitionBase definition)
    {
        Console.WriteLine("02\tOnBeforeRegisterDependencies(discoveryContext, definition)");
    }
    //3
    public override void OnAfterRegisterDependencies(ITypeDiscoveryContext discoveryContext, DefinitionBase definition)
    {
        Console.WriteLine("03\tOnAfterRegisterDependencies(discoveryContext, definition)");
    }
    //4
    public override void OnAfterInitialize(ITypeDiscoveryContext discoveryContext, DefinitionBase definition)
    {
        Console.WriteLine("04\tOnAfterInitialize(discoveryContext, definition)");
    }
    //5
    public override void OnTypeRegistered(ITypeDiscoveryContext discoveryContext)
    {
        Console.WriteLine("05\tOnTypeRegistered(discoveryContext)");
    }



    //6
    public override void OnTypesInitialized()
    {
        Console.WriteLine("06\tOnTypesInitialized()");
    }

    //7
    public override void OnAfterDiscoverTypes()
    {
        Console.WriteLine("07\tOnAfterDiscoverTypes()");
    }

    //8
    public override void OnBeforeCompleteTypeNames()
    {
        Console.WriteLine("08\tOnBeforeCompleteTypeNames()");
    }



    //9
    public override void OnBeforeCompleteName(ITypeCompletionContext completionContext, DefinitionBase definition)
    {
        Console.WriteLine("09\tOnBeforeCompleteName(completionContext, definition)");
    }
    //10
    public override void OnAfterCompleteName(ITypeCompletionContext completionContext, DefinitionBase definition)
    {
        Console.WriteLine("10\tOnAfterCompleteName(completionContext, definition)");
    }



    //11
    public override void OnTypesCompletedName()
    {
        Console.WriteLine("11\tOnTypesCompletedName()");
    }

    //12
    public override void OnAfterCompleteTypeNames()
    {
        Console.WriteLine("12\tOnAfterCompleteTypeNames()");
    }

    //13
    public override void OnBeforeMergeTypeExtensions()
    {
        Console.WriteLine("13\tOnBeforeMergeTypeExtensions()");
    }

    //14
    public override void OnAfterMergeTypeExtensions()
    {
        Console.WriteLine("14\tOnAfterMergeTypeExtensions()");
    }



    //15
    public override void OnBeforeCompleteMutationField(ITypeCompletionContext completionContext, ObjectFieldDefinition mutationField)
    {
        Console.WriteLine("15\tOnBeforeCompleteMutationField(completionContext, mutationField)");
        foreach (var item in mutationField.Arguments)
        {
            Console.WriteLine("\titem.Name: " + item.Name);
            Console.WriteLine("\titem.Parameter?.Name: " + item.Parameter?.Name);
            Console.WriteLine("\titem.RuntimeType?.Name: " + item.RuntimeType?.Name);
            Console.WriteLine("\titem.BindTo: " + item.BindTo);
            try
            {
                Console.WriteLine("\tToRuntimeType: " + completionContext.GetType<IObjectType>(item.Type!).ToRuntimeType().Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\tToRuntimeType: " + ex.Message);
            }
        }
    }



    //16
    public override void OnBeforeCompleteTypes()
    {
        Console.WriteLine("16\tOnBeforeCompleteTypes()");
    }



    //17
    public override void OnBeforeCompleteType(ITypeCompletionContext completionContext, DefinitionBase definition)
    {
        Console.WriteLine("17\tOnBeforeCompleteType(completionContext, definition)");
    }
    //18
    public override void OnAfterCompleteType(ITypeCompletionContext completionContext, DefinitionBase definition)
    {
        Console.WriteLine("18\tOnAfterCompleteType(completionContext, definition)");
        Console.WriteLine("\tcompletionContext.IsType: " + completionContext.IsType);
        Console.WriteLine("\tcompletionContext.Type.Name: " + completionContext.Type.Name);
        Console.WriteLine("\tdefinition.Name: " + definition.Name);
        Console.WriteLine("\tcompletionContext.Type is IObjectType: " + (completionContext.Type is IObjectType));
    }



    //19
    public override void OnValidateType(ITypeSystemObjectContext validationContext, DefinitionBase definition)
    {
        Console.WriteLine("19\tOnValidateType(validationContext, definition)");
    }

    //20
    public override void OnTypesCompleted()
    {
        Console.WriteLine("20\tOnTypesCompleted()");
    }

    //21
    public override void OnAfterCompleteTypes()
    {
        Console.WriteLine("21\tOnAfterCompleteTypes()");
    }

    //22
    [Obsolete]
    public override void OnAfterCreateSchema(IDescriptorContext context, ISchema schema)
    {
        Console.WriteLine("22\tOnAfterCreateSchema(context, schema)");
    }

    public override void OnCreateSchemaError(IDescriptorContext context, Exception error)
    {
        Console.WriteLine("OnCreateSchemaError(context, error)");
    }
}
