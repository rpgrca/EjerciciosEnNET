namespace Day21.Logic;
public class MonkeyMath
{
    private string _input;
    private string[] _fields;

    public int Root { get; set; }

    public MonkeyMath(string input)
    {
        _input = input;
        _fields = _input.Split(": ");

        var subFields = _fields[1].Split(" ");
        if (subFields[1] == "+")
        {
            Root = int.Parse(subFields[0]) + int.Parse(subFields[2]);
        }
        else
        {
            Root = int.Parse(subFields[0]) * int.Parse(subFields[2]);
        }
    }

}
