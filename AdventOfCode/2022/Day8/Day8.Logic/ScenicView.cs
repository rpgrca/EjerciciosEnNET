namespace Day8.Logic;

internal class ScenicView : IAlgorithm
{
    private readonly int _rows;
    private readonly int _columns;
    private readonly int[,] _patch;

    private int _currentX;
    private int _currentY;
    private int _currentTree;
 
    public int Result { get; private set; }

    public ScenicView(int rows, int columns, int[,] patch)
    {
        _rows = rows;
        _columns = columns;
        _patch = patch;

        Calculate();
    }

    private void Calculate()
    {
        var result = 0;

        for (_currentY = 1; _currentY < _rows - 1; _currentY++)
        {
            for (_currentX = 1; _currentX < _columns - 1; _currentX++)
            {
                _currentTree = _patch[_currentY, _currentX];
                var topVision = 0;
                var rightVision = 0;
                var leftVision = 0;
                var bottomVision = 0;

                topVision = AcrossVerticalAxis(_currentY - 1, (c, r, e) => e >= 0, v => v - 1);
                bottomVision = AcrossVerticalAxis(_currentY + 1, (c, r, e) => e < r, v => v + 1);
                rightVision = AcrossHorizontalAxis(_currentX + 1, (c, r, e) => e < r, v => v + 1);
                leftVision = AcrossHorizontalAxis(_currentX - 1, (c, r, e) => e >= 0, v => v - 1);

                var scenicScore = topVision * rightVision * leftVision * bottomVision;

                if (scenicScore > result)
                {
                    result = scenicScore;
                }
            }
        }

        Result = result;
    }

    private int AcrossVerticalAxis(int start, Func<int, int, int, bool> condition, Func<int, int> next)
    {
        var result = 0;

        for (var edgeY = start; condition(_currentX, _rows, edgeY); edgeY = next(edgeY))
        {
            result++;

            if (_currentTree <= _patch[edgeY, _currentX])
            {
                break;
            }
        }

        return result;
    }

    private int AcrossHorizontalAxis(int start, Func<int, int, int, bool> condition, Func<int, int> next)
    {
        var result = 0;

        for (var edgeX = start; condition(_currentY, _columns, edgeX); edgeX = next(edgeX))
        {
            result++;

            if (_currentTree <= _patch[_currentY, edgeX])
            {
                break;
            }
        }

        return result;
    }
}