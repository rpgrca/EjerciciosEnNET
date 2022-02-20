using System.Collections.Generic;

namespace Qaracter.Logic
{
    public class CableQuestion
    {
        public int PoleHeight { get; }
        public int CableLength { get; }

        public CableQuestion(int height, int length)
        {
            PoleHeight = height;
            CableLength = length;
        }
    }
}