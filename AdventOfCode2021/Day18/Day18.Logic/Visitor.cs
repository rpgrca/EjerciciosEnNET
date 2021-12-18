namespace Day18.Logic
{
    public interface IVisitable
    {
        void Accept(NumberVisitor visitor);
    }

    public class NumberVisitor
    {
        private int level = 0;

        public void Visit(SnailFishNumber snailFishNumber)
        {
        }

        public void Visit(RegularNumber regularNumber)
        {
        }
    }
}