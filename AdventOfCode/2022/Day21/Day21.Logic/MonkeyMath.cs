namespace Day21.Logic;
public class MonkeyMath
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly string[] _fields;
    private readonly Dictionary<string, int> _numbers;
    private readonly Dictionary<string, (string Operand1, string Operator, string Operand2)> _operations;

    public int Root { get; set; }

    public MonkeyMath(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        _numbers = new Dictionary<string, int>();
        _operations = new Dictionary<string, (string Operand1, string Operator, string Operand2)>();
        foreach (var line in _lines)
        {
            _fields = line.Split(": ");
            var subFields = _fields[1].Split(" ");
            if (subFields.Length > 1)
            {
                _operations.Add(_fields[0], (Operand1: subFields[0], Operator: subFields[1], Operand2: subFields[2]));
            }
            else
            {
                _numbers.Add(_fields[0], int.Parse(subFields[0]));
            }
        }

        Root = SolveEquation("root");
    }

    private int SolveEquation(string monkeyName)
    {
        if (_numbers.TryGetValue(monkeyName, out var result))
        {
            return result;
        }

        var (operand1, @operator, operand2) = _operations[monkeyName];
        return @operator switch
        {
            "+" => SolveEquation(operand1) + SolveEquation(operand2),
            "-" => SolveEquation(operand1) - SolveEquation(operand2),
            "*" => SolveEquation(operand1) * SolveEquation(operand2),
            _ => SolveEquation(operand1) / SolveEquation(operand2)
        };
    }
}
