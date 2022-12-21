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

        Root = SolveEqualityWithHumanIncognite("root");

    }

    private long SolveEqualityWithHumanIncognite(string monkeyName)
    {
        var equation = _operations["root"];
        long operand1;
        try
        {
            operand1 = SolveEquation(equation.Operand1);
        }
        catch
        {
            return SolveEquationToGet(equation.Operand1, SolveEquation(equation.Operand2));
        }

        return SolveEquationToGet(operand1, equation.Operand2);
    }

    private long SolveEquationToGet(string monkeyName, long expectedResult)
    {
        if (monkeyName == "humn")
        {
            return expectedResult;
        }

        var equation = _operations[monkeyName];
        long operand1;
        try
        {
            operand1 = SolveEquation(equation.Operand1);
        }
        catch
        {
            return SolveEquationToGet(equation.Operand1, GetConverse(equation.Operator, SolveEquation(equation.Operand2), expectedResult));
        }

        return SolveEquationToGet(GetConverse(operand1, equation.Operator, expectedResult), equation.Operand2);
    }

    private long SolveEquationToGet(long expectedResult, string monkeyName)
    {
        if (monkeyName == "humn")
        {
            return expectedResult;
        }

        var equation = _operations[monkeyName];
        long operand1;
        try
        {
            operand1 = SolveEquation(equation.Operand1);
        }
        catch
        {
            return SolveEquationToGet(equation.Operand1, GetConverse(equation.Operator, SolveEquation(equation.Operand2), expectedResult));
        }

        return SolveEquationToGet(GetConverse(operand1, equation.Operator, expectedResult), equation.Operand2);

    }

    private long GetConverse(string @operator, long previousResult, long expectedResult) => @operator switch
    {
        "+" => expectedResult - previousResult,
        "-" => expectedResult + previousResult,
        "*" => expectedResult / previousResult,
        _ => expectedResult * previousResult,
    };

    private long GetConverse(long previousResult, string @operator, long expectedResult) => @operator switch
    {
        "+" => expectedResult - previousResult,
        "-" => previousResult - expectedResult,
        "*" => expectedResult / previousResult,
        _ => expectedResult / previousResult,
    };


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



/*
    private long Operate(string operand1, string @operator, long operand2)
    {
        return @operator switch
        {
            "+" => SolveEquation(operand1) + SolveEquation(operand2),
            "-" => SolveEquation(operand1) - SolveEquation(operand2),
            "*" => SolveEquation(operand1) * SolveEquation(operand2),
            _ => SolveEquation(operand1) / SolveEquation(operand2)
        };
    }

    private long SolveEquationWhenIncogniteIsInFirstArgument(string operand, string @operator, long expectedValue)
    {
        return @operator switch
        {
            "+" => expectedValue - SolveEquation(operand),
            "-" => expectedValue + SolveEquation(operand),
            "*" => expectedValue / SolveEquation(operand),
            _ => expectedValue * SolveEquation(operand)
        };
    }

    private long SolveEquationWhenIncogniteIsInSecondArgument(string operand, string @operator, long expectedValue)
    {
        return @operator switch
        {
            "+" => expectedValue - SolveEquation(operand),
            "-" => expectedValue + SolveEquation(operand),
            "*" => expectedValue / SolveEquation(operand),
            _ => SolveEquation(operand) / expectedValue
        };
    }

    private long SolveEquationBackwards(string monkeyName)
    {
        if (_numbers.TryGetValue(monkeyName, out var result))
        {
            return result;
        }

        var (operand1AsString, @operator, operand2AsString) = _operations[monkeyName];
        if (operand1AsString == "humn")
        {
            return SolveEquationWhenIncogniteIsInFirstArgument(operand2AsString, @operator, expectedValue);
        }
        else if (operand2AsString == "humn")
        {
            return SolveEquationWhenIncogniteIsInSecondArgument(operand1AsString, @operator, expectedValue);
        }

        return SolveEquationWithHumanIncognite(operand1AsString, @operator, operand2AsString);
    }*/
}
