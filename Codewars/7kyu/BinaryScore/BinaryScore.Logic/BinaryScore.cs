using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

namespace BinaryScore.Logic;

public class BinaryScore
{
    public static BigInteger Score(BigInteger n)
    {
        if (n < 2) return n;

        var count = n.GetByteCount() * 8 + 1;
        BigInteger oldCount;
        do
        {
            count--;
            oldCount = BigInteger.Pow(2, count);
        } while (oldCount > n);

        return oldCount * 2 - 1;
    }
}