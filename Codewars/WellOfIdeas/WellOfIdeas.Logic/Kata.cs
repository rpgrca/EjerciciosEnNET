using System;
using System.Linq;

namespace WellOfIdeas.Logic
{
    public class Kata
    {
        public static string Well(string[] x) =>
            x.Count(p => p == "good") switch
            {
                0 => "Fail!",
                > 2 => "I smell a series!",
                _ => "Publish!"
            };
    }
}