using HelpFarmerCountAnimals.Logic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpFarmerCountAnimals.UnitTests;

[TestFixture]
public class SolutionTest
{
    private string GetErrorMessage(Dictionary<string, int> expected, Dictionary<string, int> actual) {
      string expected_str = GetDictioranyDescription(expected);
      string actual_str = GetDictioranyDescription(actual);
      return string.Format("Expected {0}\nbut get {1}", expected_str, actual_str);
    }
  
    private string GetDictioranyDescription(Dictionary<string, int> dict){
      StringBuilder desc = new StringBuilder();
      desc.Append("Dictionary() {");
      foreach (var pair in dict) {
        desc.AppendFormat("{{\"{0}\", {1}}}", pair.Key, pair.Value);
      }
      desc.Append("};");
      return desc.ToString();
    }
    
    [Test]
    public void BasicTests()
    {
      var expected = new Dictionary<string, int>(){
        {"rabbits", 3},
        {"chickens", 5},
        {"cows", 3}
      };
      var actual = Kata.get_animals_count(34, 11, 6);
      Assert.AreEqual(expected, actual, GetErrorMessage(expected, actual));
      
      expected = new Dictionary<string, int>(){
        {"rabbits", 30},
        {"chickens", 7},
        {"cows", 5}
      };
      actual = Kata.get_animals_count(154, 42, 10);
      Assert.AreEqual(expected, actual, GetErrorMessage(expected, actual));
    }
    
    [Test]
    public void EdgeCases()
    {
      var expected = new Dictionary<string, int>(){
        {"rabbits", 0},
        {"chickens", 3},
        {"cows", 17}
      };
      var actual = Kata.get_animals_count(74, 20, 34);
      Assert.AreEqual(expected, actual, GetErrorMessage(expected, actual));
      
      expected = new Dictionary<string, int>(){
        {"rabbits", 21},
        {"chickens", 0},
        {"cows", 17}
      };
      actual = Kata.get_animals_count(152, 38, 34);
      Assert.AreEqual(expected, actual, GetErrorMessage(expected, actual));
      
      expected = new Dictionary<string, int>(){
        {"rabbits", 11},
        {"chickens", 6},
        {"cows", 0}
      };
      actual = Kata.get_animals_count(56, 17, 0);
      Assert.AreEqual(expected, actual, GetErrorMessage(expected, actual));
    }
    
    [Test]
    public void RandomTests()
    {
      var generator = new Random();
      for (int i = 0; i < 200; i++) {
        int rabbits =  generator.Next(0,10000);
        int chickens =  generator.Next(0,10000);
        int cows =  generator.Next(0,10000);
        
        int legs = 4 * rabbits + 2 * chickens + 4 * cows;
        int heads = rabbits + chickens + cows;
        int horns = 2 * cows;
        var actual = Kata.get_animals_count(legs, heads, horns);
        var expected = new Dictionary<string, int>(){
          {"rabbits", rabbits},
          {"chickens", chickens},
          {"cows", cows}
        };
        Assert.AreEqual(expected, actual, GetErrorMessage(expected, actual));      
      }
    }
}