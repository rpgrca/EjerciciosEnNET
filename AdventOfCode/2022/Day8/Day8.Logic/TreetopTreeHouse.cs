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

        var visible = false;
        for (var currentY = 1; currentY < _rows; currentY++)
        {
            for (var currentX = 1; currentX < _columns; currentX++)
            {
                var tree = _patch[currentY, currentX];
                for (var edgeX = currentX - 1; !visible && edgeX >= 0; edgeX--)
                {
                    if (tree > _patch[currentY,edgeX])
                    {
                        visible = true;
                    }
                }

                if (! visible)
                {
                    for (var edgeX = currentX + 1; !visible && edgeX < _columns; edgeX++)
                    {
                        if (tree > _patch[currentY,edgeX])
                        {
                            visible = true;
                        }
                    }
                }

                if (! visible)
                {
                    for (var edgeY = currentY + 1; !visible && edgeY < _rows; edgeY++)
                    {
                        if (tree > _patch[edgeY,currentX])
                        {
                            visible = true;
                        }
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
