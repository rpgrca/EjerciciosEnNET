﻿namespace TakeAnArrowToTheKneeFunctionally.Logic;

using System;
using System.Linq;

// Preloaded method Tools.FromCharCode(int i) available!

public class Kata
{
    public static string ArrowFunc(int[] arr) =>
        string.Concat(arr.Select(Convert.ToChar).ToArray());
}