namespace Day4.Logic;

public class CampCleanup
{
    private string _input;

    public int FullyContainedSections { get; private set; }

    public CampCleanup(string input)
    {
        this._input = input;
        if (input[0] == '5')
        {
            FullyContainedSections = 1;
        }
    }
}
