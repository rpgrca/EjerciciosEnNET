using Xunit;
using AdventOfCode2020.Day21.Logic;

namespace AdventOfCode2020.Day21.UnitTests
{
    public class FoodMust
    {
        [Fact]
        public void ParseFoodIngredientListCorrectly()
        {
            const string data = "mxmxvkd kfcds sqjhc nhms (contains dairy, fish)";

            var sut = new Food(data);
            Assert.Collection(sut.Ingredients,
                i1 => Assert.Equal("mxmxvkd", i1),
                i2 => Assert.Equal("kfcds", i2),
                i3 => Assert.Equal("sqjhc", i3),
                i4 => Assert.Equal("nhms", i4));
        }

        [Fact]
        public void ParseAllergenListCorrectly()
        {
            const string data = "mxmxvkd kfcds sqjhc nhms (contains dairy, fish)";

            var sut = new Food(data);
            Assert.Collection(sut.Allergens,
                i1 => Assert.Equal("dairy", i1),
                i2 => Assert.Equal("fish", i2));
        }
    }
}