namespace Training_Dotnet8_CSharp12.Csharp12;

public class DefaultLambdaParametersShould
{
    [Fact]
    public void AllowDefaultLambdaParameters()
    {
        var add = (int a, int b = 1) => a + b;

        Assert.Equal(3, add(2));
    }

}
