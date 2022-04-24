namespace Grader.Logic;

public class Kata
{
    public static char Grader(double score) =>
        score switch {
            >= 0.9 and <= 1 => 'A',
            >= 0.8 => 'B',
            >= 0.7 => 'C',
            >= 0.6 => 'D',
            _ => 'F'
        };
}