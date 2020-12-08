using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day7.Logic
{
    public class Bags
    {
        private readonly string _rules;
        private List<string> _listOfRules;
        private readonly Dictionary<string, Bag> _bags = new();

        public Bags(string rules)
        {
            _rules = rules;
            CreateBagsFromRules();
        }

        private void CreateBagsFromRules()
        {
            SplitRules();
            CreateBagsFromSplitRules();
        }

        private void SplitRules() =>
            _listOfRules = _rules
                .Replace("\r", string.Empty)
                .Split("\n")
                .ToList();

        private void CreateBagsFromSplitRules() =>
            _listOfRules.ForEach(r => new Bag(r).AddMyselfTo(_bags));

        public int ThatContainBagOf(string aDescription) =>
            _bags.Values.Count(b => CanContainBagOf(aDescription, b));

        private bool CanContainBagOf(string aDescription, Bag bag) =>
            bag.CanContainBagOf(aDescription, _bags);

        public int ContainedBy(string aDescription) =>
            _bags[aDescription].CountBagsThatFitInside(_bags);
    }
}