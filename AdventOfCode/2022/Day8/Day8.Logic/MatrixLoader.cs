namespace Day8.Logic;

internal class MatrixLoader
{
    private readonly string _input;
    private string[] _lines;

    public int[,] Matrix { get; private set; }
    public int RowsCount { get; private set; }
    public int ColumnsCount { get; private set; }

    public MatrixLoader(string input)
    {
        _input = input;
        _lines = Array.Empty<string>();
        Matrix = new int[0,0];

        SplitInputInLines();
        CalculateDimensions();
        CreateMatrix();
        LoadValues();
    }

    private void SplitInputInLines() => _lines = _input.Split("\n");

    private void CalculateDimensions()
    {
        RowsCount = _lines.Length;
        ColumnsCount = _lines[0].Length;
    }

    private void CreateMatrix() => Matrix = new int[RowsCount, ColumnsCount];

    private void LoadValues()
    {
        var y = 0;
        int x;
        foreach (var line in _lines)
        {
            x = 0;
            foreach (var value in line)
            {
                Matrix[y, x] = value - '0';
                x++;
            }

            y++;
        }
    }
}