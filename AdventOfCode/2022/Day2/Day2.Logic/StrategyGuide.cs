namespace Day2.Logic;
public class StrategyGuide
{
    private string _input;
    private int[][] _scores;
    private char [][] _translation;

    public int TotalScore { get; private set; }

    public static StrategyGuide CreateForFirstPart(string input) =>
        new(input, new char[][] {
            new[] { 'X', 'Y', 'Z' },
            new[] { 'X', 'Y', 'Z' },
            new[] { 'X', 'Y', 'Z' }
        });

    public static StrategyGuide CreateForSecondPart(string input) =>
        new(input, new char[][] {
            new[] { 'Z', 'X', 'Y' },
            new[] { 'X', 'Y', 'Z' },
            new[] { 'Y', 'Z', 'X'}
        });

    private StrategyGuide(string input, char[][] translation)
    {
        _input = input;
        _translation = translation;

        _scores = new int[][]
        {
            new[] { 4, 1, 7 },
            new[] { 8, 5, 2 },
            new[] { 3, 9, 6 }
        };

        Parse();
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