namespace Day2.Logic;
public class StrategyGuide
{
    private string _input;
    private int[][] _scores;
    private char [][] _translation;

    public int TotalScore { get; private set; }

    public StrategyGuide(string input, bool firstPart)
    {
        this._input = input;

        _scores = new int[][]
        {
            new[] { 4, 1, 7 },
            new[] { 8, 5, 2 },
            new[] { 3, 9, 6 }
        };

        if (firstPart)
        {
            _translation = new char[][] {
                new[] { 'X', 'Y', 'Z' },
                new[] { 'X', 'Y', 'Z' },
                new[] { 'X', 'Y', 'Z' }
            };
            Parse();
        }
        else
        {
            _translation = new char[][] {
                new[] { 'Z', 'X', 'Y' },
                new[] { 'X', 'Y', 'Z' },
                new[] { 'Y', 'Z', 'X'}
            };
            Parse();
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

            myself = _translation[opponent - 'A'][myself - 'X'];
            points += CalculatePoints(opponent, myself);
        }

        TotalScore = points;
    }

    private int CalculatePoints(char opponent, char myself) =>
        _scores[myself - 'X'][opponent - 'A'];
}