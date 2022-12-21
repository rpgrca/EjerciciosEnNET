namespace Day21.Logic;

public class MonkeyHumanMath
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly string[] _fields;
    private readonly Dictionary<string, long> _numbers;
    private readonly Dictionary<string, (string Operand1, string Operator, string Operand2)> _operations;

    public long Root { get; set; }

    public MonkeyHumanMath(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        _numbers = new Dictionary<string, long>();
        _operations = new Dictionary<string, (string Operand1, string Operator, string Operand2)>();
        foreach (var line in _lines)
        {
            _fields = line.Split(": ");
            if (_fields[0] != "humn")
            {
                var subFields = _fields[1].Split(" ");
                if (subFields.Length > 1)
                {
                    _operations.Add(_fields[0], (Operand1: subFields[0], Operator: subFields[1], Operand2: subFields[2]));
                }
                else
                {
                    _numbers.Add(_fields[0], long.Parse(subFields[0]));
                }
            }
        }

        var root = _operations["root"];
        var operand1 = long.MinValue;
        var operand2 = long.MinValue;

        try
        {
            operand1 = SolveEquation(root.Operand1);
        }
        catch
        {
        }

        try
        {
            operand2 = SolveEquation(root.Operand2);
        }
        catch
        {
        }

        if (operand1 == long.MinValue)
        {
            Root = SolveEquationBackwards(root.Operand1, operand2);
        }
        else
        {
            Root = SolveEquationBackwards(root.Operand2, operand1);
        }
    }

    private long SolveEquation(string monkeyName)
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

    private long SolveEquationBackwards(string monkeyName, long expectedValue)
    {
        if (monkeyName == "humn")
        {
            return expectedValue;
        }

        if (_numbers.TryGetValue(monkeyName, out var result))
        {
            return result;
        }

        var (operand1, @operator, operand2) = _operations[monkeyName];
        if (operand1 == "humn")
        {
            return @operator switch
            {
                "+" => expectedValue - SolveEquation(operand2),
                "-" => expectedValue + SolveEquation(operand2),
                "*" => expectedValue / SolveEquation(operand2),
                _ => expectedValue * SolveEquation(operand2)
            };
        }
        else if (operand2 == "humn")
        {
            return @operator switch
            {
                "+" => expectedValue - SolveEquation(operand1),
                "-" => expectedValue + SolveEquation(operand1),
                "*" => expectedValue / SolveEquation(operand1),
                _ => SolveEquation(operand1) / expectedValue
            };
        }

        return @operator switch
        {
            "+" => SolveEquation(operand1) + SolveEquation(operand2),
            "-" => SolveEquation(operand1) - SolveEquation(operand2),
            "*" => SolveEquation(operand1) * SolveEquation(operand2),
            _ => SolveEquation(operand1) / SolveEquation(operand2)
        };
    }
}
