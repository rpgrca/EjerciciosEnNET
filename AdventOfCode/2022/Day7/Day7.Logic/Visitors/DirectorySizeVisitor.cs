namespace Day7.Logic.Visitors;

public class DirectorySizeVisitor : IVisitor
{
    public int Size { get; private set; }

    public void Visit(Directory directory)
    {
    }

    public void Visit(File file) => Size += file.Size;
}