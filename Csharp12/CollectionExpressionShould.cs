namespace Training_Dotnet8_CSharp12.Csharp12;

public class CollectionExpressionShould
{
    [Fact]
    public void AllowCollectionInitializers()
    {
        // Create an array:
        int[] a = [1, 2, 3, 4, 5, 6, 7, 8];

        // Create a list:
        List<string> b = ["one", "two", "three"];

        // Create a span
        Span<char> c = ['a', 'b', 'c', 'd', 'e', 'f', 'h', 'i'];

        // Create a jagged 2D array:
        int[][] twoD = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];

        // Create a jagged 2D array from variables:
        int[] row0 = [1, 2, 3];
        int[] row1 = [4, 5, 6];
        int[] row2 = [7, 8, 9];
        int[][] twoDFromVariables = [row0, row1, row2];

        Assert.Equal(1, a[0]);
        Assert.Equal("one", b[0]);
        Assert.Equal('a', c[0]);
        Assert.Equal(1, twoD[0][0]);
        Assert.Equal(1, twoDFromVariables[0][0]);
    }

    [Fact]
    public void SupportSpreading()
    {
        int[] a = [1, 2, 3];
        int[] b = [4, 5, 6];
        int[] c = [.. a, .. b];

        Assert.Equal(6, c.Length);
        Assert.True(c is [1, 2, .., 6]);
    }
}