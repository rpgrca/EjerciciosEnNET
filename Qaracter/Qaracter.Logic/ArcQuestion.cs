using System;
using System.Collections.Generic;

namespace Qarater.Logic
{
    public class ArcQuestion
    {
        public int R { get; }
        public int RABC { get; }
        public double STPerimeter { get; private set; }

        public class Builder
        {
            private int _ratio;
            private int _rectanglePerimeter;

            public Builder WithRatioOf(int value)
            {
                _ratio = value;
                return this;
            }

            public Builder WithRectanglePerimeterOf(int value)
            {
                _rectanglePerimeter = value;
                return this;
            }

            public ArcQuestion Build() => new(_ratio, _rectanglePerimeter);
        }

        private ArcQuestion(int r, int rabc)
        {
            R = r;
            RABC = rabc;

            CalculateQuarterOfCircle();
        }

        private void CalculateQuarterOfCircle() => STPerimeter = 2 * Math.PI * R;
    }
}
