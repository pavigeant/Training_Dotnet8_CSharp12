namespace Training_Dotnet8_CSharp12.Csharp11;

public class InterpolatedStringShould
{
    [Theory]
    [InlineData(100, "The usage policy for 100 is Unlimited usage")]
    [InlineData(95, "The usage policy for 95 is Unlimited usage")]
    [InlineData(82, "The usage policy for 82 is General usage, with daily safety check")]
    [InlineData(76, "The usage policy for 76 is Issues must be addressed within 1 week")]
    [InlineData(51, "The usage policy for 51 is Issues must be addressed within 1 day")]
    [InlineData(48, "The usage policy for 48 is Issues must be addressed before continued use")]
    public void SupportNewline(int safetyScore, string expectedMessage)
    {
        string message = $"The usage policy for {safetyScore} is {safetyScore switch
        {
            > 90 => "Unlimited usage",
            > 80 => "General usage, with daily safety check",
            > 70 => "Issues must be addressed within 1 week",
            > 50 => "Issues must be addressed within 1 day",
            _ => "Issues must be addressed before continued use",
        }}";

        Assert.Equal(expectedMessage, message);
    }
}
