using System.Reflection;

namespace Training_Dotnet8_CSharp12.Csharp11;

public class GenericAttributeShould
{
    [Fact]
    [BusinessRule<Br007_JameBondRule>]
    public void BeUsedIfAvailable()
    {
        var method = GetType().GetMethod(nameof(BeUsedIfAvailable))!;
        var attribute = method
            .GetCustomAttributes()
            .OfType<BusinessRuleAttribute<Br007_JameBondRule>>()
            .FirstOrDefault();

        Assert.NotNull(attribute);
        Assert.Equal("James Bond Rule", attribute.GetName());
    }
}

[System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
public sealed class BusinessRuleAttribute<T> : Attribute
    where T: IBusinessRule
{
    public string GetName() => Activator.CreateInstance<T>().GetName();
}

public interface IBusinessRule
{
    string GetName();
}

public class Br007_JameBondRule : IBusinessRule
{
    public string GetName() => "James Bond Rule";
}