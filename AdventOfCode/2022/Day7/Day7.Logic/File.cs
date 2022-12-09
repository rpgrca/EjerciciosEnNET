using Day7.Logic.Visitors;

namespace Day7.Logic;

public class File : IVisitable
{
    public int Size { get; }

    public File(int size) => Size = size;

    public void Accept(IVisitor visitor) =>
        visitor.Visit(this);
}
