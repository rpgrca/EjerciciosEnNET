using System;
using System.Linq;

namespace WellOfIdeas.Logic
{
    public class Kata
    {
        public static string Well(string[] x)
        {
            if (x.Count(p => p == "bad") >= 2) return "Fail!";
            return "";
        }
    }
}
