using Day18.Logic.Numbers;

namespace Day18.Logic.Visitors
{
    public class ReorderRegularNumberVisitor : INumberVisitor
    {
        private int _order;

        public void AddLevel()
        {
        }

        public void RemoveLevel()
        {
        }

        public void Visit(SnailFishNumber snailFishNumber)
        {
        }

        public void Visit(RegularNumber regularNumber) =>
            regularNumber.ReorderTo(_order++);
    }
}