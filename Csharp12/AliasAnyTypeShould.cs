using Point = (int x, int y);

namespace Training_Dotnet8_CSharp12.Csharp12;

public class AliasAnyTypeShould
{
    [Fact]
    public void AllowAliasAnyType()
    {
        Point point = (1, 2);
        Assert.Equal(1, point.x);
        Assert.Equal(2, point.y);
    }
}