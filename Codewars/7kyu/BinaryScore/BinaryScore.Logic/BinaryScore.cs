using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

namespace BinaryScore.Logic;

public class BinaryScore
{
    public static BigInteger Score(BigInteger n)
    {
        if (n == 0) return 0;

        var maximumAmountOfBits = (n.GetByteCount() * 8) + 1;
        BigInteger oldCount = BigInteger.Pow(2, maximumAmountOfBits);
        do
        {
            maximumAmountOfBits--;
            oldCount >>= 1;
        } while (oldCount > n);

        return (oldCount << 1) - 1;
    }
}