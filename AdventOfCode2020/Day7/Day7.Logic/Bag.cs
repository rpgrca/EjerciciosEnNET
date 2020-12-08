using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day7.Logic
{
    public class Bag
    {
        private readonly string[] _emptyDescription = { "no other bags." };
        private readonly string _rule;
        private string _description;
        private List<string> _containedBags;
        private List<ContainedBagInformation> ContainedBags { get; }

        public Bag(string rule)
        {
            ContainedBags = new List<ContainedBagInformation>();
            _rule = rule;

            ExtractDescriptionFromRule();
            ExtractContainedBagsFromRule();
        }

        private void ExtractDescriptionFromRule() =>
            _description = string.Join(" ", _rule.Split(" ").Take(2));

        private void ExtractContainedBagsFromRule()
        {
            ExtractContainedBagDescriptionsFromRule();
            AddContainedBags();
        }

        private void ExtractContainedBagDescriptionsFromRule() =>
            _containedBags = _rule[(_description.Length + " bags contain ".Length)..]
                .Split(",")
                .Except(_emptyDescription)
                .ToList();

        private void AddContainedBags() =>
            _containedBags
                .ForEach(p => ContainedBags.Add(ContainedBagInformation.Create(p)));

        public bool IsOf(string aDescription) =>
            _description == aDescription;

        public bool CanContainBagOf(string aDescription, Dictionary<string, Bag> bags = null) =>
            ContainedBags.Any(b => b.Description == aDescription) ||
            (bags != null && ContainedBags.Any(b => bags[b.Description].CanContainBagOf(aDescription, bags)));

        public int CountBagsThatFitInside(Dictionary<string, Bag> bags) =>
            CountBagsThatFitInside(this, bags);

        private int CountBagsThatFitInside(Bag bag, Dictionary<string, Bag> bags) =>
            bag.ContainedBags
                .Sum(b => (1 + CountBagsThatFitInside(bags[b.Description], bags)) * b.Amount);

        public void AddMyselfTo(Dictionary<string, Bag> bags) =>
            bags.Add(_description, this);
    }
}