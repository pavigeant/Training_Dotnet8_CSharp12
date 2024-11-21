using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Training_Dotnet8_CSharp12.Dotnet7;

public class StringSyntaxShould
{
    public void OfferSyntaxHighlighting()
    {
        PrintRegex(@"\d{3}-\d{2}-\d{4}");
        PrintJson(@"{""name"":""John""}");
        PrintUri("https://www.example.com");
        PrintDate("yyyy-MM-dd");

        void PrintRegex([StringSyntax(StringSyntaxAttribute.Regex)] string pattern) { }
        void PrintJson([StringSyntax(StringSyntaxAttribute.Json)] string json) { }
        void PrintUri([StringSyntax(StringSyntaxAttribute.Uri)] string uri) { }
        void PrintDate([StringSyntax(StringSyntaxAttribute.DateTimeFormat)] string dateFormat) { }
    }
}

public class GenericMathShould
{
    public T Add<T>(T left, T right)
        where T : INumber<T>
    {
        return left + right;
    }

    [Fact]
    public void AddIntegers()
    {
        var result = Add(1, 2);
        Assert.Equal(3, result);
    }

    [Fact]
    public void AddDecimals()
    {
        var result = Add(1.1m, 2.2m);
        Assert.Equal(3.3m, result);
    }

    [Fact]
    public void AddFloats()
    {
        var result = Add(1.1f, 2.2f);
        Assert.Equal(3.3f, result);
    }

    // IAdditionOperators<TSelf,TOther,TResult>      x + y
    // IBitwiseOperators<TSelf,TOther,TResult>       x & y, 'x | y', x ^ y, and ~x
    // IComparisonOperators<TSelf,TOther,TResult>    x < y, x > y, x <= y, and x >= y
    // IDecrementOperators<TSelf>                    --x and x--
    // IDivisionOperators<TSelf,TOther,TResult>      x / y
    // IEqualityOperators<TSelf,TOther,TResult>      x == y and x != y
    // IIncrementOperators<TSelf>                    ++x and x++
    // IModulusOperators<TSelf,TOther,TResult>       x % y
    // IMultiplyOperators<TSelf,TOther,TResult>      x * y
    // IShiftOperators<TSelf,TOther,TResult>         x << y and x >> y
    // ISubtractionOperators<TSelf,TOther,TResult>   x - y
    // IUnaryNegationOperators<TSelf,TResult>        -x
    // IUnaryPlusOperators<TSelf,TResult>            +x
}