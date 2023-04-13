namespace DecoratorStream;

public class DecoratorStreamMust
{
    [Fact]
    public void Test1()
    {
        byte[] message = "Hello, world!"u8.ToArray();
        using var stream = new MemoryStream();
        using var decoratorStream = new DecoratorStream(stream, "First line: ");
        decoratorStream.Write(message, 0, message.Length);
        stream.Position = 0;
        Assert.Equal("First line: Hello, world!", new StreamReader(stream).ReadLine());
    }
}