using System;
using System.Linq;

namespace WellOfIdeas.Logic
{
    public class Kata
    {
        public static string Well(string[] x)
        {
            if (x.Count(p => p == "good") >= 1 && x.Count(p => p == "good") <= 2) return "Publish!";
            if (x.Count(p => p == "good") > 2) return "I smell a series!";
            if (x.Count(p => p == "bad") >= 2) return "Fail!";
            return "Fail!";
        }
    }
}
