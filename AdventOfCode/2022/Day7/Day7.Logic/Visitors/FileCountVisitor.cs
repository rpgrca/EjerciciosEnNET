namespace Day7.Logic.Visitors;

public class FileCountVisitor : IVisitor
{
    public int Count { get; private set; }

    public void Visit(Directory directory)
    {        
    }

    public void Visit(File file) => Count++;
}