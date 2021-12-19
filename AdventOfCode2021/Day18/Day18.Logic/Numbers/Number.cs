using Day18.Logic.Visitors;

namespace Day18.Logic.Numbers
{
    public abstract class Number : IVisitable
    {
        public abstract void Accept(INumberVisitor visitor);
    }
}