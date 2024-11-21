namespace Training_Dotnet8_CSharp12.Csharp12;

public class RefReadonlyParameterShould
{
    [Fact]
    public void AllowRefReadonlyParameter()
    {
        var a = 1;
        var b = 2;
        var c = 3;

        var result = Add(ref a, b, c);

        Assert.Equal(6, result);
    }

    private static int Add(ref readonly int a, int b, int c)
    {
        return a + b + c;
    }
}