using System;

public class Kata
{
  public static int[] MergeArrays(int[] arr1, int[] arr2) =>
    arr1.Union(arr2).Distinct().OrderBy(b => b).ToArray();
}