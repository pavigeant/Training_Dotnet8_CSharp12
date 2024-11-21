namespace Training_Dotnet8_CSharp12.Csharp11;

public class RawLiteralStringShould
{
    [Fact]
    public void AllowRawString()
    {
        var singleLine = """This is a "raw string literal". It can contain characters like \, ' and ".""";

        Assert.Equal(@"This is a ""raw string literal"". It can contain characters like \, ' and "".", singleLine);
    }

    [Fact]
    public void AllowMultilineString()
    {
        string multiline = """
            This is a multiline
            string that can span
            multiple lines.

            Notice the line before the
            closing triple quote.

            This line denote where the string "starts".
            """;

        Assert.Equal(@"This is a multiline
string that can span
multiple lines.

Notice the line before the
closing triple quote.

This line denote where the string ""starts"".", multiline);

        // Note that there no new line after the final dot.
    }

    [Fact]
    public void AllowInterpolation()
    {
        string name = "John";
        string multiline = $"""
            Good morning {name},

            How are you today?

            Have a great day!
            """;

        Assert.Equal(@"Good morning John,

How are you today?

Have a great day!", multiline);
    }

    [Fact]
    public void AllowEscapingForInterpolatedString()
    {
        int X = 2;
        int Y = 3;

        var pointMessage = $"""The point {X}, {Y} is {Math.Sqrt(X * X + Y * Y):F3} from the origin""";
        Assert.Equal(@"The point 2, 3 is 3.606 from the origin", pointMessage);

        var pointMessageWithExcaping = $$"""The point {{{X}}, {{Y}}} is {{Math.Sqrt(X * X + Y * Y):F3}} from the origin""";
        Assert.Equal(@"The point {2, 3} is 3.606 from the origin", pointMessageWithExcaping);
    }
}
