using HelpFarmerCountAnimals.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace HelpFarmerCountAnimals.UnitTests;

[TestFixture]
public class SolutionTest
{
[Test]
public void BasicTests()
{
    var expected = new Dictionary<string, int>(){
    {"rabbits", 3},
    {"chickens", 5},
    {"cows", 3}
    };
    Assert.AreEqual(expected, Kata.get_animals_count(34, 11, 6));
    
    expected = new Dictionary<string, int>(){
    {"rabbits", 30},
    {"chickens", 7},
    {"cows", 5}
    };
    Assert.AreEqual(expected, Kata.get_animals_count(154, 42, 10));
}
}