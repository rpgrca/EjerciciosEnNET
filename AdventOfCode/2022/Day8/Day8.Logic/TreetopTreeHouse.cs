namespace Day8.Logic;
public class TreetopTreeHouse
{
    private readonly string _input;

    public int VisibleTreesFromOutside { get; set; }

    public TreetopTreeHouse(string input)
    {
        _input = input;
        VisibleTreesFromOutside = 9;
    }

}
