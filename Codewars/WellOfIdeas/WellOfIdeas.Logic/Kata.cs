using System;
using System.Linq;

namespace WellOfIdeas.Logic
{
    public class Kata
    {
        public static string Well(string[] x)
        {
            var goods = x.Count(p => p == "good");
            if (goods == 0)
            {
                return "Fail!";
            }

            if (goods > 2)
            {
                return "I smell a series!";
            }

            return "Publish!";
        }
    }
}
