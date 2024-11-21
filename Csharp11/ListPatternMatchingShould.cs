namespace Training_Dotnet8_CSharp12.Csharp11;

public class ListPatternMatchingShould
{
    // Best thing since sliced bread

    [Fact]
    public void ValidateArray()
    {
        int[] numbers = [1, 2, 3];

        Assert.True(numbers is [1, 2, 3]);
        Assert.False(numbers is [1, 2, 4]);
        Assert.False(numbers is [1, 2, 3, 4]);
        Assert.True(numbers is [0 or 1, <= 2, >= 3]); // Allow validation on each array element
    }

    [Fact]
    public void PartiallyValidateArray()
    {
        int[] numbers = [1, 2, 3, 4, 5, 6];

        Assert.True(numbers is [1, ..]); // At least one element
        Assert.True(numbers is [_, 2, .., 6]); // Starts with any int, 2, ends with 6, with any number of elements in between
        Assert.True(numbers is [.., 5, 6]); // Ends with 5, 6 with any number of elements before
    }

    [Fact]
    public void AllowExtractingVariableFromArray()
    {
        int[] numbers = [1, 2, 3];

        if (numbers is [1, var second, 3])
        {
            Assert.Equal(2, second);
        }
        else
        {
            Assert.Fail();
        }
    }

    [Fact]
    public void SimplifySplitting()
    {
        var parts = @"domain\user".Split(@"\");

        if (parts is [_, var user])
        {
            Assert.Equal("user", user);
        }
        else
        {
            Assert.Fail();
        }
    }

    [Fact]
    public void AcceptSpecificSliceLength()
    {
        int[] numbers = [1, 0, 0, 6];
        int[] numbers2 = [1, 2, 3, 4, 5, 6];
        int[] numbers3 = [1, 0, 0, 0, 0, 0, 6];


        Assert.True(numbers is [1, .. { Length: 2 or 4 }, 6]);
        Assert.True(numbers2 is [1, .. { Length: 2 or 4 }, 6]);
        Assert.False(numbers3 is [1, .. { Length: 2 or 4 }, 6]);
    }
}