namespace Day11.Logic;

public class MonkeysLoader
{
    private readonly string _input;
    private readonly string[] _lines;

    public List<Monkey1> Monkeys { get; }

    public MonkeysLoader(string input)
    {
        _input = input + "\n";
        _lines = _input.Split("\n");
        Monkeys = new List<Monkey1>();

        Parse();
    }

    private void Parse()
    {
        string[] tokens = Array.Empty<string>();
        List<long> items = new();
        char operation = ' ';
        string operand = string.Empty;
        int divisor = -1;
        int targetOnSuccess = -1;
        int targetOnFailure = -1;
        Monkey1 monkey;

        foreach (var line in _lines)
        {
            if (line.StartsWith("Monkey "))
            {
                continue;
            }
            else if (line.StartsWith("  Starting items: "))
            {
                items = line.Split(":")[1].Split(",").ToList().Select(p => long.Parse(p)).ToList();
            }
            else if (line.StartsWith("  Operation: "))
            {
                tokens = line.Split(":")[1].Trim().Split(" ");
                if (tokens[0] != "new" || tokens[1] != "=" || tokens[2] != "old") throw new ArgumentException();
                operation = tokens[3][0];
                operand = tokens[4];
            }
            else if (line.StartsWith("  Test: "))
            {
                tokens = line.Split(":")[1].Trim().Split(" ");
                if (tokens[0] != "divisible" || tokens[1] != "by") throw new ArgumentException();
                divisor = int.Parse(tokens[2]);
            }
            else if (line.StartsWith("    If true:"))
            {
                tokens = line.Split(":")[1].Trim().Split(" ");
                if (tokens[0] != "throw" || tokens[1] != "to" || tokens[2] != "monkey") throw new ArgumentException();
                targetOnSuccess = int.Parse(tokens[3]);
            }
            else if (line.StartsWith("    If false:"))
            {
                tokens = line.Split(":")[1].Trim().Split(" ");
                if (tokens[0] != "throw" || tokens[1] != "to" || tokens[2] != "monkey") throw new ArgumentException();
                targetOnFailure = int.Parse(tokens[3]);
            }
            else if (string.IsNullOrWhiteSpace(line))
            {
                monkey = new Monkey1(items, operation, operand, divisor, targetOnSuccess, targetOnFailure);
                Monkeys.Add(monkey);

                tokens = Array.Empty<string>();
                items = new();
                operation = ' ';
                operand = string.Empty;
                divisor = -1;
                targetOnSuccess = -1;
                targetOnFailure = -1;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}