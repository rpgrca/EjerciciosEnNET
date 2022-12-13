namespace Day13.Logic;
public class DistressSignalDecoder
{
    public int SumOfCorrectIndexes { get; set; }

    public DistressSignalDecoder(string input)
    {
        SumOfCorrectIndexes = 0;

        var lines = input.Split("\n");
        List<int> sectionsAbove;
        var tokensAbove = lines[0][1..^1].Split(",").ToList();
        if (tokensAbove.Count == 1)
        {
            if (string.IsNullOrWhiteSpace(tokensAbove[0]))
            {
                sectionsAbove = new List<int>();
            }
            else
            {
                sectionsAbove = tokensAbove.Select(int.Parse).ToList();
            }
        }
        else
        {
            sectionsAbove = tokensAbove.Select(p => int.Parse(p)).ToList();
        }
        
        List<int> sectionsBelow;
        var tokensBelow = lines[1][1..^1].Split(",").ToList();
        if (tokensBelow.Count == 1)
        {
            if (string.IsNullOrWhiteSpace(tokensBelow[0]))
            {
                sectionsBelow = new List<int>();
            }
            else
            {
                sectionsBelow = tokensBelow.Select(int.Parse).ToList();
            }
        }
        else
        {
            sectionsBelow = tokensBelow.Select(int.Parse).ToList();
        }

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
