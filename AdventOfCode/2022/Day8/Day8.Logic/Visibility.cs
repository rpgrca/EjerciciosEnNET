namespace Day8.Logic;

internal class Visibility : IAlgorithm
{
    private readonly int _rows;
    private readonly int _columns;
    private readonly int[,] _patch;

    private int _currentX;
    private int _currentY;
    private int _currentTree;
    private bool _visible;

    public int Result { get; private set; }

    public Visibility(int rows, int columns, int[,] patch)
    {
        _rows = rows;
        _columns = columns;
        _patch = patch;

        Calculate();
    }

    private void Calculate()
    {
        Result = _rows * _columns;

        for (_currentY = 1; _currentY < _rows - 1; _currentY++)
        {
            for (_currentX = 1; _currentX < _columns - 1; _currentX++)
            {
                _visible = false;
                _currentTree = _patch[_currentY, _currentX];

                AcrossHorizontalAxis(0, (e, c) => e < c, v => v + 1);
                AcrossVerticalAxis(0, (e, c) => e < c, v => v + 1);
                AcrossHorizontalAxis(_columns - 1, (e, c) => e > c, v => v - 1);
                AcrossVerticalAxis(_rows - 1, (e, c) => e > c, v => v - 1);

                if (!_visible)
                {
                    Result--;
                }
            }
        }
    }

    private void AcrossHorizontalAxis(int start, Func<int, int, bool> condition, Func<int, int> next)
    {
        if (!_visible)
        {
            var maximum = 0;
            for (var edgeX = start; condition(edgeX, _currentX); edgeX = next(edgeX))
            {
                if (_patch[_currentY, edgeX] > maximum)
                {
                    maximum = _patch[_currentY, edgeX];
                }
            }

            if (_currentTree > maximum)
            {
                _visible = true;
            }
        }
    }

    private void AcrossVerticalAxis(int start, Func<int, int, bool> condition, Func<int, int> next)
    {
        if (! _visible)
        {
            var maximum = 0;
            for (var edgeY = start; condition(edgeY, _currentY); edgeY = next(edgeY))
            {
                if (_patch[edgeY, _currentX] > maximum)
                {
                    maximum = _patch[edgeY, _currentX];
                }
            }

            if (_currentTree > maximum)
            {
                _visible = true;
            }
        }
    }
}