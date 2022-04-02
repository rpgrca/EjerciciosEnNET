namespace Day16.Logic
{
    public interface IVisitable
    {
        void Accept(VersionSumVisitor visitor);
    }
}