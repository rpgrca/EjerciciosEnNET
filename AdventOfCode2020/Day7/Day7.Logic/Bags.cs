using System.Linq;
using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Day7.Logic
{
    public class Bags
    {
        private readonly string _rules;
        private readonly Dictionary<string, Bag> _bags = new();

        public Bags(string rules)
        {
            _rules = rules;
            CreateBagsFromRules();
        }

        private void CreateBagsFromRules()
        {
            foreach (var rule in _rules.Replace("\r", string.Empty).Split("\n"))
            {
                var bag = new Bag(rule);
                _bags.Add(bag.Description, bag);
            }
        }

        public List<Bag> ThatContainBagOf(string aDescription)
        {
            var bags = new List<Bag>();

            foreach (var bag in _bags.Values)
            {
                if (CanContainBagOf(aDescription, bag))
                {
                    bags.Add(bag);
                }
            }

            return bags;
        }

        private bool CanContainBagOf(string aDescription, Bag bag)
        {
            var result = false;

            if (bag.ContainedBags.Any(b => b.Name == aDescription))
            {
                return true;
            }

            foreach (var containedBag in bag.ContainedBags)
            {
                result = CanContainBagOf(aDescription, _bags[containedBag.Name]);
                if ( result)
                {
                    break;
                }
            }

            return result;
        }

        public int ContainedBy(string aDescription)
        {
            return CountBagsThatFitInside(aDescription);
        }

        private int CountBagsThatFitInside(string aDescription)
        {
            var bag = _bags[aDescription];
            var subTotal = 0;
            foreach (var bagContained in bag.ContainedBags)
            {
                subTotal += (1 + CountBagsThatFitInside(bagContained.Name)) * bagContained.Amount;
            }

            return subTotal;
        }
    }
}