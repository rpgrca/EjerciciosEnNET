using System.ComponentModel;
using System.Reflection;
using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day7.Logic
{
    public record ContainedBagInformation(string Name, int Amount);

    public class Bag
    {
        private readonly string _rule;
        public string Description { get; private set; }
        public List<ContainedBagInformation> ContainedBags { get; }

        public Bag(string rule)
        {
            ContainedBags = new List<ContainedBagInformation>();
            _rule = rule;
            ExtractDescriptionFromRule();
            ExtractContainedBagsFromRule();
        }

        private void ExtractDescriptionFromRule() =>
            Description = string.Join(" ", _rule.Split(" ").Take(2));

        private void ExtractContainedBagsFromRule()
        {
            var containedBags = _rule[(Description.Length + " bags contain ".Length)..].Trim();
            if (! containedBags.Contains("no other bags"))
            {
                var containing = containedBags.Split(",");
                foreach (var containedDescription in containing)
                {
                    var parsedInformation = containedDescription.Trim().Split(" ");
                    ContainedBags.Add(new ContainedBagInformation(string.Join(" ", parsedInformation[1..3]), int.Parse(parsedInformation[0])));
                }
            }
        }

        public bool IsOf(string aDescription) =>
            Description == aDescription;

        public bool CanContainBagOf(string aDescription) =>
            _rule[Description.Length..].Contains(aDescription);
    }
}