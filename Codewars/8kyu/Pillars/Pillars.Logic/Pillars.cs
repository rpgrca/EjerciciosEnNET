using System;

namespace Pillars.Logic
{
    public static class Kata
    {
        public static int Pillars(int numPill, int dist, int width)
        {
            if (numPill == 1) return 0;
            return (numPill - 2) * width + (numPill - 1) * (dist * 100);
        }
    }
}
