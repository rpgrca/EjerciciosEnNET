using System.Collections.Generic;

namespace Codewars.ConnectTheDots.Logic
{
    public interface ILine
    {
        void TraceTo(List<(int Y, int X)> dots);
    }
}