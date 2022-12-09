namespace Day7.Logic.Visitors;

public class DirectoryCountVisitor : IVisitor
{
    public int Count { get; private set; }

    public void Visit(Directory directory) => Count++;

    public void Visit(File file)
    {
    }
}
