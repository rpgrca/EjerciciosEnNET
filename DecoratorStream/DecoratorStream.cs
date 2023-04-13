using System;
using System.IO;
using System.Text;

namespace DecoratorStream;

public class DecoratorStream : Stream
{
	private Stream _stream;
	private string _prefix;
	private bool _firstTime;

	public override bool CanSeek { get { return false; } }

	public override bool CanWrite { get { return true; } }

	public override long Length { get; }

	public override long Position { get; set; }

	public override bool CanRead { get { return false; } }

	public DecoratorStream(Stream stream, string prefix) : base()
	{
		_stream = stream;
		_prefix = prefix;
		_firstTime = true;
	}

	public override void SetLength(long length)
	{
		_stream.SetLength(length + _prefix.Length);
	}

	public override void Write(byte[] bytes, int offset, int count)
	{
		if (_firstTime)
		{
			byte[] firstLine = System.Text.ASCIIEncoding.UTF8.GetBytes(_prefix);
			_stream.Write(firstLine, offset, firstLine.Length);
        	_stream.Write(bytes, 0, count);
			_firstTime = false;
		}
		else
		{
			_stream.Write(bytes, offset, count);
		}
	}

	public override int Read(byte[] bytes, int offset, int count)
	{
		return _stream.Read(bytes, offset, count);
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return _stream.Seek(offset, origin);
	}

	public override void Flush()
	{
		_stream.Flush();
	}
/*
    public static void Main(string[] args)
    {
        byte[] message = new byte[]{0x48, 0x65, 0x6c, 0x6c, 0x6f, 0x2c, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64, 0x21};
        using (MemoryStream stream = new MemoryStream())
        {
            using (DecoratorStream decoratorStream = new DecoratorStream(stream, "First line: "))
            {
                decoratorStream.Write(message, 0, message.Length);
                stream.Position = 0;
                Console.WriteLine(new StreamReader(stream).ReadLine());  //should print "First line: Hello, world!"
            }
        }
    }*/
}