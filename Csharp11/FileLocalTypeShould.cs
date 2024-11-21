namespace Training_Dotnet8_CSharp12.Csharp11;

public class FileLocalTypeShould
{
    [Fact]
    public void AllowFileLocalType()
    {
        var employee = new Employee("John", "Doe");
        Assert.Equal("John", employee.FirstName);
        Assert.Equal("Doe", employee.LastName);
    }
}

file record Employee(string FirstName, string LastName);
