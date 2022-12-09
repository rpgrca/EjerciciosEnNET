namespace Day8.Logic;

public class TreetopTreeHouse
{
    public int Result { get; private set; }

    public static TreetopTreeHouse CreateForFirstPuzzle(string input) =>
        new(input, (r, c, p) => new Visibility(r, c, p));

    public static TreetopTreeHouse CreateForSecondPuzzle(string input) =>
        new(input, (r, c, p) => new ScenicView(r, c, p));

    private TreetopTreeHouse(string input, Func<int, int, int[,], IAlgorithm> algorithmCreator)
    {
        var matrixLoader = new MatrixLoader(input);
        var patch = matrixLoader.Matrix;
        var rows = matrixLoader.RowsCount;
        var columns = matrixLoader.ColumnsCount;

        Result = algorithmCreator(rows, columns, patch).Result;
    }
}