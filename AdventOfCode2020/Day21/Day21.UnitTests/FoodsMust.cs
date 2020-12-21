using Xunit;
using AdventOfCode2020.Day21.Logic;

namespace AdventOfCode2020.Day21.UnitTests
{
    public class FoodsMust
    {
        [Fact]
        public void LoadDataCorrectly()
        {
            const string data = @"mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
trh fvjkl sbzzf mxmxvkd (contains dairy)
sqjhc fvjkl (contains soy)
sqjhc mxmxvkd sbzzf (contains fish)";

            var sut = new Foods(data);
            Assert.Equal(4, sut.Count);
       }

        [Fact]
        public void CalculateAmountOfIngredientsWithoutAllergens()
        {
            const string data = @"mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
trh fvjkl sbzzf mxmxvkd (contains dairy)
sqjhc fvjkl (contains soy)
sqjhc mxmxvkd sbzzf (contains fish)";

            var sut = new Foods(data);

            sut.CalculateIngredientsWithoutAllergens();
            Assert.Equal(5, sut.ApparitionsOfIngredientsWithoutAllergensInFood);
       }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new Foods(PuzzleData.PUZZLE_DATA);

            sut.CalculateIngredientsWithoutAllergens();
            Assert.Equal(2061, sut.ApparitionsOfIngredientsWithoutAllergensInFood);
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new Foods(PuzzleData.PUZZLE_DATA);

            sut.CalculateIngredientsWithoutAllergens();
            Assert.Equal("cdqvp,dglm,zhqjs,rbpg,xvtrfz,tgmzqjz,mfqgx,rffqhl", sut.CanonicalDangerousIngredientList);
        }
    }
}