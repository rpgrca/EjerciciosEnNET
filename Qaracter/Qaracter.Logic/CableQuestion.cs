using System.Collections.Generic;

namespace Qaracter.Logic
{
    public class CableQuestion
    {
        public int PoleHeight { get; }
        public int CableLength { get; }
        public int HeightAtCenter { get; }
        public double PoleDistance { get; set; }

        public CableQuestion(int poleHeight, int cableLength, int heightAtCenter)
        {
            PoleHeight = poleHeight;
            CableLength = cableLength;
            HeightAtCenter = heightAtCenter;

            CalculateDistanceBetweenPoles();
        }

        private void CalculateDistanceBetweenPoles()
        {
            
        }
    }
}