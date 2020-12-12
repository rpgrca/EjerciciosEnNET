using System.Collections.Generic;
using AdventOfCode2020.Day11.Logic;

namespace AdventOfCode2020.Day11.UnitTests
{
    public class TestableShyBehaviour : ShyBehaviour
    {
        public int CallCountSurroundingPlaces(List<string> layout, int i, int j) =>
            base.CountSurroundingPlaces(layout, i, j, '#');
    }
}