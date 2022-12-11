namespace Day11.UnitTests;

public static class Constants
{
    public const string SAMPLE_INPUT = @"Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3

Monkey 1:
  Starting items: 54, 65, 75, 74
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 79, 60, 97
  Operation: new = old * old
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 3:
  Starting items: 74
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 1";

    public const string PUZZLE_INPUT = @"Monkey 0:
  Starting items: 74, 73, 57, 77, 74
  Operation: new = old * 11
  Test: divisible by 19
    If true: throw to monkey 6
    If false: throw to monkey 7

Monkey 1:
  Starting items: 99, 77, 79
  Operation: new = old + 8
  Test: divisible by 2
    If true: throw to monkey 6
    If false: throw to monkey 0

Monkey 2:
  Starting items: 64, 67, 50, 96, 89, 82, 82
  Operation: new = old + 1
  Test: divisible by 3
    If true: throw to monkey 5
    If false: throw to monkey 3

Monkey 3:
  Starting items: 88
  Operation: new = old * 7
  Test: divisible by 17
    If true: throw to monkey 5
    If false: throw to monkey 4

Monkey 4:
  Starting items: 80, 66, 98, 83, 70, 63, 57, 66
  Operation: new = old + 4
  Test: divisible by 13
    If true: throw to monkey 0
    If false: throw to monkey 1

Monkey 5:
  Starting items: 81, 93, 90, 61, 62, 64
  Operation: new = old + 7
  Test: divisible by 7
    If true: throw to monkey 1
    If false: throw to monkey 4

Monkey 6:
  Starting items: 69, 97, 88, 93
  Operation: new = old * old
  Test: divisible by 5
    If true: throw to monkey 7
    If false: throw to monkey 2

Monkey 7:
  Starting items: 59, 80
  Operation: new = old + 6
  Test: divisible by 11
    If true: throw to monkey 2
    If false: throw to monkey 3";
}