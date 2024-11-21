namespace Training_Dotnet8_CSharp12.Csharp11;

public class RequiredShould
{
    [Fact]
    public void PreventCreatingAClassWithoutRequiredProperties()
    {
        var person = new Person();


        Assert.NotNull(person.FirstName);
        Assert.NotNull(person.LastName);
        Assert.Null(person.MiddleName);
    }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
}
