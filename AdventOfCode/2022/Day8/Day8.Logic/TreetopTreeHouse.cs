namespace Day8.Logic;
public class TreetopTreeHouse
{
    private readonly string _input;
    private int _rows;
    private int _columns;
    private int[,] _patch;

    public int VisibleTreesFromOutside { get; set; }

    public TreetopTreeHouse(string input)
    {
        _input = input;

        var lines = _input.Split("\n");
        _rows = lines.Length;
        _columns = lines[0].Length;

        VisibleTreesFromOutside = _rows * _columns;

        _patch = new int[_rows,_columns];
        var y = 0;
        int x;
        foreach (var line in _input.Split("\n"))
        {
            x = 0;
            foreach (var tree in line)
            {
                _patch[y,x] = tree - '0';
                x++;
            }

            y++;
        }

        bool visible;
        for (var currentY = 1; currentY < _rows - 1; currentY++)
        {
            for (var currentX = 1; currentX < _columns - 1; currentX++)
            {
                visible = false;
                var maximum = 0;
                var tree = _patch[currentY, currentX];

                if (! visible)
                {
                    for (var edgeX = 0; edgeX < currentX; edgeX++)
                    {
                        if (_patch[currentY, edgeX] > 0)
                        {
                            maximum = _patch[currentX, edgeX];
                        }
                    }

                    if (tree > maximum)
                    {
                        visible = true;
                    }
                }

                // check from right to left
                if (! visible)
                {
                    maximum = 0;
                    for (var edgeX = _columns - 1; edgeX > currentX; edgeX--)
                    {
                        if (_patch[currentY,edgeX] > maximum)
                        {
                            maximum = _patch[currentY, edgeX];
                        }
                    }

                    if (tree > maximum)
                    {
                        visible = true;
                    }
                }

                // check from bottom to top
                if (! visible)
                {
                    maximum = 0;
                    for (var edgeY = _rows - 1; edgeY > currentY; edgeY--)
                    {
                        if (_patch[edgeY, currentX] > maximum)
                        {
                            maximum = _patch[edgeY, currentX];
                        }
                    }

                    if (tree > maximum)
                    {
                        visible = true;
                    }
                }

                // check from top to bottom
                if (! visible)
                {
                    maximum = 0;
                    for (var edgeY = 0; edgeY < currentY; edgeY++)
                    {
                        if (_patch[edgeY, currentX] > maximum)
                        {
                            maximum = _patch[edgeY, currentX];
                        }
                    }

                    if (tree > maximum)
                    {
                        visible = true;
                    }
                }

                if (! visible)
                {
                    VisibleTreesFromOutside--;
                }
            }
        }
    }
}
