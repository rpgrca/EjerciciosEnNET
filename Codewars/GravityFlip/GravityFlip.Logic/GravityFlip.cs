using System;
using System.Linq;

namespace GravityFlip.Logic
{
    public class GravityFlip
    {
        public int[] State { get; set; }

        public GravityFlip() => State = Array.Empty<int>();

        public void Flip(char dir, int[] arr)
        {
            if (dir == 'R')
                State = arr.OrderBy(p => p).ToArray();
            else
            if (dir == 'L')
                State = arr.OrderByDescending(p => p).ToArray();
            else
                State = arr;
        }
    }
}
