using Day7.Logic.Visitors;

namespace Day7.Logic;

public interface IVisitable
{
    void Accept(IVisitor visitor);
}
