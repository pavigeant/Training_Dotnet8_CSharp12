namespace Training_Dotnet8_CSharp12.Csharp11;

public class Utf8StringShould
{
    [Fact]
    public void AllowUtf8String()
    {
        ReadOnlySpan<byte> AuthWithTrailingSpace = [0x41, 0x55, 0x54, 0x48, 0x20];
        ReadOnlySpan<byte> AuthStringLiteral = "AUTH "u8;

        Assert.Equal(AuthWithTrailingSpace.ToArray(), AuthStringLiteral.ToArray());
    }
}