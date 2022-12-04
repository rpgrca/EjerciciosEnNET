namespace Day4.Logic;

public class CampCleanup
{
    private string _input;

    public int FullyContainedSections { get; private set; }
    public int OverlappedSections { get; private set; }

    public CampCleanup(string input)
    {
        this._input = input;

        Parse();
    }

    private void Parse()
    {
        foreach (var line in _input.Split('\n'))
        {
            var pairs = line.Split(',');
            var leftSections = pairs[0].Split('-').Select(p => int.Parse(p)).ToArray();
            var rightSections = pairs[1].Split('-').Select(p => int.Parse(p)).ToArray();

            if (rightSections[0] <= leftSections[0] && leftSections[1] <= rightSections[1])
            {
                FullyContainedSections++;
            }
            else if (leftSections[0] <= rightSections[0] && rightSections[1] <= leftSections[1])
            {
                FullyContainedSections++;
            }

            if (rightSections[0] <= leftSections[1])
            {
                if (rightSections[1] >= leftSections[0]) 
                {
                    OverlappedSections++;
                }
            }
        }
    }
}
