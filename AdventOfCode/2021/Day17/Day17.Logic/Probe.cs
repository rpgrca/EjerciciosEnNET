namespace Day17.Logic
{
    public class Probe
    {
        private int _positionX;
        private int _positionY;
        private int _velocityX;
        private int _velocityY;
        public int HighestPoint { get; private set; }

        public Probe(int velocityX, int velocityY)
        {
            _velocityX = velocityX;
            _velocityY = velocityY;
        }

        public bool IsPositionedAt(int x, int y) =>
            _positionX == x && _positionY == y;

        public bool IsCurrentVelocityEqualTo(int velocityX, int velocityY) =>
            _velocityX == velocityX && _velocityY == velocityY;

        public void Step(int steps)
        {
            for (var step = 0; step < steps; step++)
            {
                _positionX += _velocityX;
                _positionY += _velocityY;

                if (_velocityX > 0)
                {
                    _velocityX--;
                }
                else if (_velocityX < 0)
                {
                    _velocityX++;
                }

                _velocityY--;

                if (_positionY > HighestPoint)
                {
                    HighestPoint = _positionY;
                }
            }
        }

        public bool IsWithin((int Minimum, int Maximum) rangeX, (int Minimum, int Maximum) rangeY) =>
            _positionX >= rangeX.Minimum && _positionY <= rangeY.Maximum;

        public bool HasntReached((int Minimum, int Maximum) rangeX, (int Minimum, int Maximum) rangeY) =>
            _positionX <= rangeX.Maximum && _positionY >= rangeY.Minimum;
    }
}