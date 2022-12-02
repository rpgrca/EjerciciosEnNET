namespace Day2.Logic;
public class StrategyGuide
{
    private string _input;

    public int TotalScore { get; private set; }

    public StrategyGuide(string input)
    {
        this._input = input;

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

            switch (myself)
            {
                case 'X':
                    points += 1 + opponent switch {
                        'A' => 3,
                        'B' => 0,
                        'C' => 6
                    };
                    break;

                case 'Y':
                    points += 2 + opponent switch {
                        'A' => 6,
                        'B' => 3,
                        'C' => 0
                    };
                    break;

                case 'Z':
                    points += 3 + opponent switch {
                        'A' => 0,
                        'B' => 6,
                        'C' => 3
                    };
                    break;
            }
        }

        TotalScore = points;
    }
}
