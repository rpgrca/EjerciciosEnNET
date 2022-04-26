namespace FindTheMiddleElement.Logic;

public class Kata
{
    public static int Gimme(double[] inputArray) =>
        inputArray.Select((p, i) => (p, i)).OrderBy(p => p.p).Skip(1).First().i;
}