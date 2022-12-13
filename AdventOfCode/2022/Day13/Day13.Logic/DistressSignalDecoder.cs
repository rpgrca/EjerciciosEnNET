namespace Day13.Logic;
public class DistressSignalDecoder
{
    public int SumOfCorrectIndexes { get; set; }

    public DistressSignalDecoder(string input)
    {
        SumOfCorrectIndexes = 0;

        var lines = input.Split("\n");
        var sectionsAbove = lines[0][1..^1].Split(",").Select(p => int.Parse(p)).ToList();
        var sectionsBelow = lines[1][1..^1].Split(",").Select(p => int.Parse(p)).ToList();

        if (sectionsAbove.Count == sectionsBelow.Count)
        {
            for (var index = 0; index < sectionsAbove.Count; index++)
            {
                if (sectionsAbove[index] < sectionsBelow[index])
                {
                    SumOfCorrectIndexes += 1;
                    return;
                }
                else if (sectionsAbove[index] > sectionsBelow[index])
                {
                    return;
                }
            }

            // equals?
        }
        else if (sectionsAbove.Count < sectionsBelow.Count)
        {
            for (var index = 0; index < sectionsAbove.Count; index++)
            {
                if (sectionsAbove[index] < sectionsBelow[index])
                {
                    SumOfCorrectIndexes += 1;
                    return;
                }
                else if (sectionsAbove[index] > sectionsBelow[index])
                {
                    return;
                }
            }

            SumOfCorrectIndexes += 1;
            return;
        }
        else
        {
            for (var index = 0; index < sectionsBelow.Count; index++)
            {
                if (sectionsAbove[index] < sectionsBelow[index])
                {
                    SumOfCorrectIndexes += 1;
                    return;
                }
                else if (sectionsAbove[index] > sectionsBelow[index])
                {
                    return;
                }
            }

            return;
        }
    }
}
