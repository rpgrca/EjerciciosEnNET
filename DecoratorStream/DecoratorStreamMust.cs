namespace DecoratorStream;

public class DecoratorStreamMust
{
    [Fact]
    public void SolveExampleCase()
    {
        var message = "Hello, world!"u8.ToArray();
        using var stream = new MemoryStream();
        using var decoratorStream = new DecoratorStream(stream, "First line: ");
        decoratorStream.Write(message, 0, message.Length);
        stream.Position = 0;
        Assert.Equal("First line: Hello, world!", new StreamReader(stream).ReadLine());
    }

    [Fact]
    public void SolveMultipleWrites()
    {
        var message = "Hello, world!"u8.ToArray();
        using var stream = new MemoryStream();
        using var decoratorStream = new DecoratorStream(stream, "First line: ");
        decoratorStream.Write(message, 0, message.Length);
        decoratorStream.Write(message, 0, message.Length);
        stream.Position = 0;
        Assert.Equal("First line: Hello, world!Hello, world!", new StreamReader(stream).ReadLine());
    }
}