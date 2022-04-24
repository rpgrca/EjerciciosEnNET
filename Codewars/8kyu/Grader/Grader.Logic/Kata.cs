namespace Grader.Logic;

public class Kata
{
    public static char Grader(double score) =>
        score switch {
            > 1 => 'F',
            >= 0.9 => 'A',
            >= 0.8 => 'B',
            >= 0.7 => 'C',
            >= 0.6 => 'D',
            _ => 'F'
        };
}