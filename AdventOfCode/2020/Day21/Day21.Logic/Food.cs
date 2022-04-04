using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day21.Logic
{
    [DebuggerDisplay("{_label}")]
    public class Food
    {
        private readonly string _label;

        public List<string> Ingredients { get; private set; }
        public List<string> Allergens { get; private set; }

        public Food(string label)
        {
            _label = label;
            Ingredients = new List<string>();
            Allergens = new List<string>();

            ParseLabel();
        }

        private void ParseLabel()
        {
            CreateIngredientList();
            CreateAllergenList();
        }

        private void CreateIngredientList() =>
            Ingredients = _label.Split(" (")[0].Split(" ").ToList();

        private void CreateAllergenList() =>
            Allergens = _label.Split(" (contains ")[1].Replace(")", string.Empty).Split(", ").ToList();
    }
}