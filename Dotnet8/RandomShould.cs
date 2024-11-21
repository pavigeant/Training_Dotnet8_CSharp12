namespace Training_Dotnet8_CSharp12.Dotnet8;

public class RandomShould
{
    [Fact]
    public void GetItemsSortedRandomly()
    {
        var random = new Random();
        ReadOnlySpan<int> items = [ 1, 2, 3, 4, 5, 6, 7, 8, 9 ];

        var random3Items = random.GetItems(items, 3);
        Assert.Equal(3, random3Items.Length);
    }

    [Fact]
    public void ShuffleItems()
    {
        var random = new Random();
        Span<int> items = [1, 2, 3, 4, 5, 6, 7, 8, 9];

        random.Shuffle(items);
        Assert.Equal(9, items.Length);
    }
}