using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode2020.Day21.Logic
{
    public class Foods
    {
        private readonly string _labels;
        private readonly List<Food> _foods;
        private readonly Dictionary<string, List<Food>> _allergens;
        private readonly Dictionary<string, List<string>> _allergensByIngredient;
        private List<string> _ingredientsThatMayContainAllergen;

        public int Count => _foods.Count;
        public List<string> IngredientsWithAllergens { get; private set; }
        public List<string> IngredientsWithoutAllergens { get; private set; }
        public int ApparitionsOfIngredientsWithoutAllergensInFood { get; private set; }
        public string CanonicalDangerousIngredientList { get; private set; }

        public Foods(string labels)
        {
            _labels = labels;
            _foods = new List<Food>();
            _allergens = new Dictionary<string, List<Food>>();
            _allergensByIngredient = new Dictionary<string, List<string>>();
            _ingredientsThatMayContainAllergen = new List<string>();
            CanonicalDangerousIngredientList = string.Empty;
            IngredientsWithoutAllergens = new List<string>();
            IngredientsWithAllergens = new List<string>();

            ParseLabels();
        }

        private void ParseLabels()
        {
            CreateFood();
            CreateAllergenList();
        }

        private void CreateFood() =>
            _labels.Split("\n").ToList().ForEach(l => _foods.Add(new Food(l)));

        private void CreateAllergenList()
        {
            foreach (var food in _foods)
            {
                foreach (var allergen in food.Allergens)
                {
                    if (! _allergens.ContainsKey(allergen))
                    {
                        _allergens.Add(allergen, new List<Food>());
                    }

                    _allergens[allergen].Add(food);
                }
            }
        }

        public void CalculateIngredientsWithoutAllergens()
        {
            foreach (var (allergen, foods) in _allergens)
            {
                FindCommonFoodIngredientsThatMayContainAllergen(foods);
                StoreSuspiciousIngredients();
                ClassifyAllergen(allergen);
                StoreFoodIngredientsWithoutAllergens(foods);
            }

            RefreshIngredientsWithoutAllergens();
            CountSafeIngredientsInFoods();
            GuessIngredientAllergens();
        }

        private void FindCommonFoodIngredientsThatMayContainAllergen(List<Food> value) =>
            _ingredientsThatMayContainAllergen = value
                .SelectMany(p => p.Ingredients)
                .GroupBy(p => p)
                .Where(p => p.Count() >= value.Count)
                .Select(p => p.Key)
                .ToList();

        private void StoreSuspiciousIngredients()
        {
            IngredientsWithAllergens.AddRange(_ingredientsThatMayContainAllergen);
            IngredientsWithAllergens = IngredientsWithAllergens.Distinct().ToList();
        }

        private void ClassifyAllergen(string key) =>
            _allergensByIngredient.Add(key, _ingredientsThatMayContainAllergen);

        private void StoreFoodIngredientsWithoutAllergens(List<Food> food)
        {
            var ingredientsThatDontContainGivenAllergen = food
                .SelectMany(p => p.Ingredients)
                .GroupBy(p => p)
                .Select(p => p.Key)
                .Where(p => !IngredientsWithAllergens.Contains(p))
                .ToList();

            IngredientsWithoutAllergens.AddRange(ingredientsThatDontContainGivenAllergen);
        }

        private void RefreshIngredientsWithoutAllergens()
        {
            IngredientsWithoutAllergens = IngredientsWithoutAllergens.Distinct().ToList();
            IngredientsWithoutAllergens.RemoveAll(i => IngredientsWithAllergens.Contains(i));
        }

        private void CountSafeIngredientsInFoods() =>
            ApparitionsOfIngredientsWithoutAllergensInFood = _foods
                .SelectMany(food =>
                    food.Ingredients
                        .Where(ingredient => IngredientsWithoutAllergens.Contains(ingredient))
                        .Select(_ => food))
                .Count();

        private void GuessIngredientAllergens()
        {
            while (AnyAllergenAppearsInMoreThanOneIngredient())
            {
                foreach (var allergen in AllergensThatAppearInOnlyOneIngredient())
                {
                    FromAllergenListRemove(allergen.Key, allergen.Value[0]);
                }
            }

            CreateCanonicalDangerousIngredientList();
        }

        private bool AnyAllergenAppearsInMoreThanOneIngredient() =>
            _allergensByIngredient.Any(p => p.Value.Count > 1);

        private IEnumerable<KeyValuePair<string, List<string>>> AllergensThatAppearInOnlyOneIngredient() =>
            _allergensByIngredient.Where(p => p.Value.Count == 1);

        private void FromAllergenListRemove(string key, string value) =>
            _allergensByIngredient
                .Where(p => p.Key != key)
                .Select(p => p.Value)
                .ToList()
                .ForEach(p => p.RemoveAll(q => q == value));

        private void CreateCanonicalDangerousIngredientList() =>
            CanonicalDangerousIngredientList = string.Join(",", _allergensByIngredient
                .OrderBy(p => p.Key)
                .Select(p => p.Value[0]));
    }
}