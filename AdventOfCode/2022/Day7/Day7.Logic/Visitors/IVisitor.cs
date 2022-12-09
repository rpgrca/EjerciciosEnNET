namespace Day7.Logic.Visitors;

public interface IVisitor
{
    void Visit(Directory directory);
    void Visit(File file);
}
