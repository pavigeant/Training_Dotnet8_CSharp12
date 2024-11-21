using System.Numerics;

namespace Training_Dotnet8_CSharp12.Csharp11;

public class StaticVirtualInterfaceShould
{
    [Fact]
    public void AllowOverridingOperators()
    {
        var sequence = new RepeatSequence();
        Assert.Equal("A", sequence.ToString());
        sequence++;
        Assert.Equal("AA", sequence.ToString());
        sequence++;
        Assert.Equal("AAA", sequence.ToString());
    }

    [Fact]
    public void AllowGenericMaths()
    {
        var point = new Point<float>(X: 1.5f, Y: 2.3f);
        var move = point + new Translation<float>(XOffset: 0.2f, YOffset: 6.23f);

        Assert.Equal(1.7f, move.X);
        Assert.Equal(8.53f, move.Y);
    }
}

public interface IGetNext<T> where T : IGetNext<T>
{
    static string GetNextWhat() => typeof(T).Name;

    static abstract T operator ++(T other);
}

public struct RepeatSequence : IGetNext<RepeatSequence>
{
    private const char Ch = 'A';
    public string Text = new(Ch, 1);

    public RepeatSequence() { }

    public static RepeatSequence operator ++(RepeatSequence other)
        => other with { Text = other.Text + Ch };

    public override readonly string ToString() => Text;
}

public record Translation<T>(T XOffset, T YOffset) : 
    IAdditiveIdentity<Translation<T>, Translation<T>>
    where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
{
    public static Translation<T> AdditiveIdentity =>
        new(XOffset: T.AdditiveIdentity, YOffset: T.AdditiveIdentity);
}

public record Point<T>(T X, T Y) : IAdditionOperators<Point<T>, Translation<T>, Point<T>>
    where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
{
    public static Point<T> operator +(Point<T> left, Translation<T> right) =>
        left with { X = left.X + right.XOffset, Y = left.Y + right.YOffset };
}