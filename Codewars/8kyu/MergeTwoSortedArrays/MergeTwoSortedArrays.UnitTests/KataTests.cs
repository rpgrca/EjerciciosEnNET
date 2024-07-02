using System;
using System.Linq;
using NUnit.Framework;

namespace MergeTwoSortedArrays.Logic;

[TestFixture]
public class KataTests
{
    [Test]
    public void SampleTest()
    {
        Assert.AreEqual(new[] {1, 2, 3, 4, 5, 6, 7, 8}, 
            Kata.MergeArrays(new[] {1, 2, 3, 4}, new[] {5, 6, 7, 8}));

        Assert.AreEqual(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
            Kata.MergeArrays(new[] {1, 3, 5, 7, 9}, new[] {10, 8, 6, 4, 2}));

        Assert.AreEqual(new[] {1, 2, 3, 4, 5, 7, 9, 10, 11, 12},
            Kata.MergeArrays(new[] {1, 3, 5, 7, 9, 11, 12}, new[] {1, 2, 3, 4, 5, 10, 12}));

        Assert.AreEqual(new int[] { }, 
            Kata.MergeArrays(new int[] { }, new int[] { }));

        Assert.AreEqual(new[] {1, 2, 3}, 
            Kata.MergeArrays(new[] {1, 2, 3}, new int[] { }));

        Assert.AreEqual(new int[] {1, 2, 3, 4, 5}, 
            Kata.MergeArrays(new int[] { }, new int[] {1, 2, 3, 4, 5}));

        Assert.AreEqual(new int[] {-3, -2, -1, 0, 1, 2, 3, 4},
            Kata.MergeArrays(new[] {-3, -2, -1, 0}, new int[] {1, 2, 3, 4}));
    }

    [Test]
    public void SameOrderTest()
    {
        Assert.AreEqual(new[] {1, 2, 3, 4, 5, 6, 7, 8},
            Kata.MergeArrays(new[] {1, 2, 3, 4}, new[] {5, 6, 7, 8}));

        Assert.AreEqual(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
            Kata.MergeArrays(new[] {10, 8, 6, 4, 2}, new[] {9, 7, 5, 3, 1}));

        Assert.AreEqual(new[] {-20, -10, -5, 0, 6, 7, 8, 9, 10, 25, 35, 36, 37, 38, 39, 40, 50, 62},
            Kata.MergeArrays(new[] {-20, 35, 36, 37, 39, 40},
                new[] {-10, -5, 0, 6, 7, 8, 9, 10, 25, 38, 50, 62}));
    }

    [Test]
    public void DifferentOrdersTest()
    {
        Assert.AreEqual(new[] {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 18, 20},
            Kata.MergeArrays(new[] {5, 6, 7, 8, 9, 10},
                new[] {20, 18, 15, 14, 13, 12, 11, 4, 3, 2}));

        Assert.AreEqual(new[] {5, 9, 10, 12, 15, 18, 20, 25, 30, 35, 45, 50},
            Kata.MergeArrays(new[] {45, 30, 20, 15, 12, 5}, new[] {9, 10, 18, 25, 35, 50}));

        Assert.AreEqual(new[] {-13, -9, -8, -3, -2, 0, 2, 4, 5, 6, 7, 8, 15, 32, 42, 74, 90, 102, 134, 216},
            Kata.MergeArrays(new[] {-8, -3, -2, 4, 5, 6, 7, 15, 42, 90, 134},
                new[] {216, 102, 74, 32, 8, 2, 0, -9, -13}));
    }

    [Test]
    public void MoreTest()
    {
        Assert.AreEqual(new[] {-100, -34, -27, -8, 5, 6, 12, 23, 25, 56, 124, 213, 325, 601},
            Kata.MergeArrays(new[] {-100, -27, -8, 5, 23, 56, 124, 325},
                new[] {-34, -27, 6, 12, 25, 56, 213, 325, 601}));

        Assert.AreEqual(new[] {-300, -293, -103, -46, -31, -22, -5, 0, 2, 7, 18, 19, 74, 231},
            Kata.MergeArrays(new[] {18, 7, 2, 0, -22, -46, -103, -293},
                new[] {-300, -293, -46, -31, -5, 0, 18, 19, 74, 231}));

        Assert.AreEqual(new[] {-201, -73, -4, 73, 105},
            Kata.MergeArrays(new[] {105, 73, -4, -73, -201},
                new[] {-201, -73, -4, 73, 105}));
    }

    [Test]
    public void RandomTest()
    {
        for (var i = 0; i < 300; i++)
        {
            var arr1 = RandomArray();
            var arr2 = RandomArray();
            var expected = Solution(arr1, arr2);

            var message = FailureMessage(arr1, arr2, expected);
            var actual = Kata.MergeArrays(arr1, arr2);

            Assert.AreEqual(expected, actual, message);
        }
    }

    private static int[] Solution(int[] arr1, int[] arr2)
    {
        return arr1.Concat(arr2).Distinct().OrderBy(x => x).ToArray();
    }

    private static readonly Random Rand = new Random();

    private static int[] RandomArray()
    {
        var arr = Enumerable.Range(0, Rand.Next(10)).Select(x => Rand.Next(-100, 100)).Distinct().ToArray();
        return Rand.Next(1, 10) > 5 ? arr.OrderBy(x => x).ToArray() : arr.OrderByDescending(x => x).ToArray();
    }

    private static string FailureMessage(int[] arr1, int[] arr2, int[] value)
    {
        return $"Should return [{string.Join(", ", value)}] with arr1=[{string.Join(", ", arr1)}] and arr2=[{string.Join(", ", arr2)}]";
    }
}
