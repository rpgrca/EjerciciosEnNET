namespace Day18.Logic.Visitors
{
    public interface IVisitable
    {
        void Accept(INumberVisitor visitor);
    }
}