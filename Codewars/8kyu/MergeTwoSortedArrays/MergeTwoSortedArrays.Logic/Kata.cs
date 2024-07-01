using System;

public class Kata
{
  public static int[] MergeArrays(int[] arr1, int[] arr2)
  {
    var newList = arr1.ToList();
    newList.AddRange(arr2);
    return newList.Distinct().OrderBy(b => b).ToArray();
  }
}