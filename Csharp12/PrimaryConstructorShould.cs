namespace Training_Dotnet8_CSharp12.Csharp12;

public class PrimaryConstructorShould
{
    [Fact]
    public void AllowPrimaryConstructor()
    {
        var person = new Person("John", "Doe");
        Assert.Equal("John Doe", person.ToString());
    }
}

file class Person(string firstName, string lastName)
{
    public override string ToString() => $"{firstName} {lastName}";
}
