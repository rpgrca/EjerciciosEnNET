namespace Day2.Logic;
public class StrategyGuide
{
    private string _input;

    public int TotalScore { get; private set; }

    public StrategyGuide(string input, bool firstPart)
    {
        this._input = input;

        if (firstPart)
        {
            Parse();
        }
        else
        {
            Parse2();
        }
    }

    private void Parse()
    {
        var lines = _input.Split("\n");
        var points = 0;
        foreach (var line in lines)
        {
            var opponent = line[0];
            var myself = line[2];
            points += CalculatePoints(opponent, myself);
        }

        TotalScore = points;
    }

    private static int CalculatePoints(char opponent, char myself)
    {
        int[][] scores = new int[][]
        {
            new[] { 4, 1, 7 },
            new[] { 8, 5, 2 },
            new[] { 3, 9, 6 }
        };

        return scores[myself - 'X'][opponent - 'A'];
    }

    private void Parse2()
    {
        var lines = _input.Split("\n");
        var points = 0;
        char [][] scores = new char[][] {
            new[] { 'Z', 'X', 'Y' },
            new[] { 'X', 'Y', 'Z' },
            new[] { 'Y', 'Z', 'X'}
        };

        foreach (var line in lines)
        {
            var opponent = line[0];
            var myself = line[2];

            myself = scores[opponent - 'A'][myself - 'X'];
            points += CalculatePoints(opponent, myself);
        }

        TotalScore = points;
    }
}