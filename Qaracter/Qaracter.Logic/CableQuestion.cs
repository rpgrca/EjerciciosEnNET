using System.Collections.Generic;

namespace Qaracter.Logic
{
    public class CableQuestion
    {
        public int PoleHeight { get; }
        public int CableLength { get; }
        public int HeightAtCenter { get; }

        public CableQuestion(int poleHeight, int cableLength, int heightAtCenter)
        {
            PoleHeight = poleHeight;
            CableLength = cableLength;
            HeightAtCenter = heightAtCenter;
        }
    }
}