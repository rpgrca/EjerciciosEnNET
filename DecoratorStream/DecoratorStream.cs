using System.Text;

namespace DecoratorStream;

public class DecoratorStream : Stream
{
	private readonly Stream _stream;
	private readonly string _prefix;
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

    public override void SetLength(long length) => _stream.SetLength(length + _prefix.Length);

    public override void Write(byte[] bytes, int offset, int count)
	{
		if (_firstTime)
		{
			byte[] firstLine = Encoding.UTF8.GetBytes(_prefix);
			_stream.Write(firstLine, 0, firstLine.Length);
        	_stream.Write(bytes, offset, count);
			_firstTime = false;
		}
		else
		{
			_stream.Write(bytes, offset, count);
		}
	}

    public override int Read(byte[] bytes, int offset, int count) => _stream.Read(bytes, offset, count);

    public override long Seek(long offset, SeekOrigin origin) => _stream.Seek(offset, origin);

    public override void Flush() => _stream.Flush();
}