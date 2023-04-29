public class UserInputMust
{
    [Fact]
    public void ReturnText_WhenUsingTextInput()
    {
        var sut = new TextInput();
        sut.Add('1');
        sut.Add('a');
        sut.Add('0');
        Assert.Equal("1a0", sut.GetValue());
    }

    [Fact]
    public void ReturnNumber_WhenUsingNumericInput()
    {
        var sut = new NumericInput();
        sut.Add('1');
        sut.Add('a');
        sut.Add('0');
        Assert.Equal("10", sut.GetValue());
    }
}