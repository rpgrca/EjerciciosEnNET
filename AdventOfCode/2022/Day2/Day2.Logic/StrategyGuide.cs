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

    private void Parse2()
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
                    points += opponent switch {
                        'A' => 3,
                        'B' => 1,
                        'C' => 2
                    };
                    break;

                case 'Y':
                    points += 3 + opponent switch {
                        'A' => 1,
                        'B' => 2,
                        'C' => 3
                    };
                    break;

                case 'Z':
                    points += 6 + opponent switch {
                        'A' => 2,
                        'B' => 3,
                        'C' => 1
                    };
                    break;
            }
        }

        TotalScore = points;
    }
}