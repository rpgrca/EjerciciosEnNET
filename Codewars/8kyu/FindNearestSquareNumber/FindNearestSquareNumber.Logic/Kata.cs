namespace FindNearestSquareNumber.Logic;

public class Kata
{
  public static int NearestSq(int n)
  {
    var squareRoot = (int)Math.Sqrt(n);
    var potentialPow = (int)Math.Pow(squareRoot, 2);
    
    if (potentialPow == n)
    {
        return n;
    }
    else
    {
        var higherPow = (int)Math.Pow(squareRoot + 1, 2);
        return n - potentialPow < higherPow - n? potentialPow : higherPow;
    }
  }
}
