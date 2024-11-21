namespace Training_Dotnet8_CSharp12.Dotnet8;

public class TimeAbstractionShould
{
    [Fact]
    public void SupportInjectTimeProvider()
    {
        var services = new ServiceCollection();
        services.AddSingleton(TimeProvider.System);

        var provider = services.BuildServiceProvider();
        var timeProvider = provider.GetRequiredService<TimeProvider>();

        Assert.Equal(DateTime.Now, timeProvider.GetLocalNow(), TimeSpan.FromSeconds(2));

        // There is also a fake time provider for testing
        // Microsoft.Extensions.Time.Testing.FakeTimeProvider
    }
}
