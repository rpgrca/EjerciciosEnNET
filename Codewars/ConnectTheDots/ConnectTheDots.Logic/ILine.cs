using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.ConnectTheDots.Logic
{
    public interface ILine
    {
        void TraceTo(List<(int Y, int X)> dots);
    }
}